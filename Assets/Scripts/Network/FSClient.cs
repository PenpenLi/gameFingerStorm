#region

using ExitGames.Client.Photon;
using ExitGames.Client.Photon.LoadBalancing;

using UnityEngine;

using HashTable = ExitGames.Client.Photon.Hashtable;

#endregion

public class FSClient : LoadBalancingClient
{
    #region Fields

    public int evCount = 0;

    public GameController gameController;

    public Vector3 lastMoveEv;

    private bool isCreator;

    #endregion

    #region Public Properties

    public string ErrorMessageToShow { get; set; }

    #endregion

    #region Public Methods and Operators

    public override void DebugReturn(DebugLevel level, string message)
    {
        base.DebugReturn(level, message);
        Debug.Log(message);
    }

    public override void OnEvent(EventData photonEvent)
    {
        base.OnEvent(photonEvent);

        switch (photonEvent.Code)
        {
                //case (byte)1:
                //	Hashtable content = photonEvent.Parameters[ParameterCode.CustomEventContent] as Hashtable;
                //    this.lastMoveEv = (Vector3)content[(byte)1];
                //    this.evCount++;
                //    break;

            case EventCode.PropertiesChanged:
                var data = photonEvent.Parameters[ParameterCode.Properties] as Hashtable;
                this.DebugReturn(DebugLevel.ALL, "got something: " + (data["data"] as string));
                break;
            case EventCode.Join:
                //foreach(System.Collections.Generic.KeyValuePair<byte, object> kv in photonEvent.Parameters)
                //{
                //		Debug.Log(kv.Key + " " + kv.Value);
                //}
                Hashtable content = photonEvent.Parameters[ParameterCode.PlayerProperties] as Hashtable;
                if (content.ContainsKey((byte)255))
                {
                    string name = (string)content[(byte)255];
                    Debug.Log(name);
                    if (!name.Equals(SystemInfo.deviceName) || !this.isCreator && name.Equals(SystemInfo.deviceName))
                    {
                        this.gameController.MyFactionType = this.isCreator ? FactionType.Blue : FactionType.Red;
                        this.gameController.GetFSM().ChangeState(GameState_BeforeStartGame.Instance());
                    }
                }
                break;
            case EventCode.CreateBuilding:
                HashTable content1 = photonEvent.Parameters[ParameterCode.CustomEventContent] as HashTable;
                FactionType faction1 = (FactionType)content1[(byte)1];
                if (faction1 != this.gameController.MyFactionType)
                {
                    Vector3 pos = (Vector3)content1[(byte)2];
                    BuildingType buildingType = (BuildingType)content1[(byte)3];
                    GameObject building = BuildingsManager.GetInstance().CreateNewBuilding(buildingType, faction1, pos);
                    BuildingController buildingCtrl = building.GetComponent<BuildingController>();
                    buildingCtrl.GetFSM().ChangeState(Building_StateBuilding.Instance());
                }
                break;
            case EventCode.GameOver:
                HashTable content2 = photonEvent.Parameters[ParameterCode.CustomEventContent] as HashTable;
                FactionType faction2 = (FactionType)content2[(byte)1];
                if (faction2 != this.gameController.MyFactionType)
                {
                    this.gameController.ViewController.ShowGameResultView(true);
                    Time.timeScale = 0;
                }
                break;
             case EventCode.UpgradeBuilding:
                {
                    Hashtable contentUpgrade = photonEvent.Parameters[ParameterCode.CustomEventContent] as Hashtable;
                    FactionType faction3 = (FactionType)contentUpgrade[(byte)1];
                    if (faction3 != this.gameController.MyFactionType)
                    {
                        int buildingId = (int)contentUpgrade[(byte)2];
                        GameObject building = BuildingsManager.GetInstance().GetBuildingById(buildingId);
                        if (building != null)
                        {
                            BuildingController buildingCtrl = building.GetComponent<BuildingController>();
                            buildingCtrl.UpgradeBuilding();
                        }
                    }
                }
                break;
            case EventCode.ReleasePlayerSkill:
                {
                    Hashtable contentPlayerSkill = photonEvent.Parameters[ParameterCode.CustomEventContent] as Hashtable;
                    FactionType faction4 = (FactionType)contentPlayerSkill[(byte)1];
                    if (faction4 != this.gameController.MyFactionType)
                    {
                        string skillName = (string)contentPlayerSkill[(byte)2];
                        GameObject playerSkillPanel = GameObject.Find("PlayerSkillPanel");
                        if (playerSkillPanel != null)
                        {
                            UIPlayerSkillController playerSkillCtrl =
                                playerSkillPanel.GetComponent<UIPlayerSkillController>();

                            switch (skillName)
                            {
                                case "FireBall":
                                    {
                                        Vector3 pos = (Vector3)contentPlayerSkill[(byte)3];
                                        playerSkillCtrl.ReleaseFireBall(pos,faction4);
                                    }
                                    break;
                                case "LightningBolt":
                                    playerSkillCtrl.ReleaseLightningBolt(faction4);
                                    break;
                                case "BraySurgery":
                                    playerSkillCtrl.ReleaseBraySurgery(faction4);
                                    break;
                                case "Heal":
                                    playerSkillCtrl.ReleaseHeal(faction4);
                                    break;
                                case "Bloodlust":
                                    playerSkillCtrl.ReleaseBloodlust(faction4);
                                    break;
                            }
                        }
                        
                    }
                    break;
                }
        }
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        base.OnOperationResponse(operationResponse);
        this.DebugReturn(DebugLevel.ERROR, operationResponse.ToStringFull());

        switch (operationResponse.OperationCode)
        {
            case OperationCode.Authenticate:
                if (operationResponse.ReturnCode == ErrorCode.InvalidAuthentication)
                {
                    this.ErrorMessageToShow =
                        string.Format(
                            "Authentication failed. Your AppId: {0}.\nMake sure to set the AppId in DemoGUI.cs by replacing \"<insert your app id here>\".\nResponse: {1}",
                            this.AppId,
                            operationResponse.ToStringFull());
                    this.DebugReturn(DebugLevel.ERROR, this.ErrorMessageToShow);
                }
                if (operationResponse.ReturnCode == ErrorCode.InvalidOperationCode
                    || operationResponse.ReturnCode == ErrorCode.InternalServerError)
                {
                    this.ErrorMessageToShow =
                        string.Format(
                            "Authentication failed. You successfully connected but the server ({0}) but it doesn't know the 'authenticate'. Check if it runs the Loadblancing server-logic.\nResponse: {1}",
                            this.MasterServerAddress,
                            operationResponse.ToStringFull());
                    this.DebugReturn(DebugLevel.ERROR, this.ErrorMessageToShow);
                }
                break;

            case OperationCode.CreateGame:
                if (!string.IsNullOrEmpty(this.GameServerAddress) && this.GameServerAddress.StartsWith("127.0.0.1"))
                {
                    this.ErrorMessageToShow =
                        string.Format(
                            "The master forwarded you to a gameserver with address: {0}.\nThat address points to 'this computer' anywhere. This might be a configuration error in the game server.",
                            this.GameServerAddress);
                    this.DebugReturn(DebugLevel.ERROR, this.ErrorMessageToShow);
                }
                break;

            case OperationCode.JoinRandomGame:
                if (!string.IsNullOrEmpty(this.GameServerAddress) && this.GameServerAddress.StartsWith("127.0.0.1"))
                {
                    this.ErrorMessageToShow =
                        string.Format(
                            "The master forwarded you to a gameserver with address: {0}.\nThat address points to 'this computer' anywhere. This might be a configuration error in the game server.",
                            this.GameServerAddress);
                    this.DebugReturn(DebugLevel.ERROR, this.ErrorMessageToShow);
                }

                if (operationResponse.ReturnCode != 0)
                {
                    Debug.Log("Create Room");
                    this.isCreator = true;
                    this.OpCreateRoom(null, true, true, 2, null, null);
                }
                break;
        }
    }

    public override void OnStatusChanged(StatusCode statusCode)
    {
        base.OnStatusChanged(statusCode);

        switch (statusCode)
        {
            case StatusCode.Exception:
            case StatusCode.ExceptionOnConnect:
                Debug.LogWarning(
                    "Exception on connection level. Is the server running? Is the address (" + this.MasterServerAddress
                    + ") reachable?");
                break;
        }
    }

    public void SendCreateBuilding(Vector3 pos, BuildingType buildingType)
    {
        Hashtable evData = new Hashtable();
        evData[(byte)1] = this.gameController.MyFactionType;
        evData[(byte)2] = pos;
        evData[(byte)3] = (int)buildingType;
        this.loadBalancingPeer.OpRaiseEvent(EventCode.CreateBuilding, evData, true, 0);
    }

    public void SendUpgradeBuilding(int buildingId)
    {
        Hashtable evData = new Hashtable();
        evData[(byte)1] = this.gameController.MyFactionType;
        evData[(byte)2] = buildingId;
        this.loadBalancingPeer.OpRaiseEvent(EventCode.UpgradeBuilding, evData, true, 0);
    }

    public void SendReleasePlayerSkill(string skillName, Vector3 position)
    {
        Hashtable evData = new Hashtable();
        evData[(byte)1] = this.gameController.MyFactionType;
        evData[(byte)2] = skillName;
        evData[(byte)3] = position;
        this.loadBalancingPeer.OpRaiseEvent(EventCode.ReleasePlayerSkill, evData, true, 0);
    }

    public void SendGameResult()
    {
        HashTable evData = new HashTable();
        evData[(byte)1] = this.gameController.MyFactionType;
        this.loadBalancingPeer.OpRaiseEvent(EventCode.GameOver, evData, true, 0);
    }

    #endregion
}