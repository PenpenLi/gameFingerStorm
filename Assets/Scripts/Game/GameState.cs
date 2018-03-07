using UnityEngine;

public class GameState_GlobalState : State<GameController>
{
    #region Static Fields

    private static GameState_GlobalState instance;

    #endregion

    #region Public Methods and Operators

    public static GameState_GlobalState Instance()
    {
        return instance ?? (instance = new GameState_GlobalState());
    }

    public override void Enter(GameController entityType)
    {
    }

    public override void Execute(GameController entityType)
    {
		GameController gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();
		if(gameCtrl.GameType == GameType.PVP && entityType.Client != null)
		{
			entityType.Client.Service();
		}
    }

    public override void Exit(GameController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(GameController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class GameState_HomePage : State<GameController>
{
    #region Static Fields

    private static GameState_HomePage instance;

    #endregion

    #region Public Methods and Operators

    public static GameState_HomePage Instance()
    {
        return instance ?? (instance = new GameState_HomePage());
    }

    public override void Enter(GameController entityType)
    {
        if (entityType.ViewController != null)
        {
            entityType.ViewController.ShowHomePage();
        }
    }

    public override void Execute(GameController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(GameController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(GameController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class GameState_Matching : State<GameController>
{
    #region Static Fields

    private static GameState_Matching instance;

    private bool joiningRoom;

    #endregion

    #region Public Methods and Operators

    public static GameState_Matching Instance()
    {
        return instance ?? (instance = new GameState_Matching());
    }

    public override void Enter(GameController entityType)
    {
        entityType.ViewController.SetHomePageButtonStatus(false);
        entityType.ViewController.ShowShadowCover();

        entityType.Client = new FSClient();
        entityType.Client.MasterServerAddress = "app-eu.exitgamescloud.com:5055";
        entityType.Client.AppId = "78162ccb-b912-423b-bf93-7f6ac0210adf";
        entityType.Client.AppVersion = "1.0";
        entityType.Client.PlayerName = UnityEngine.SystemInfo.deviceName ?? "Player";
        entityType.Client.gameController = entityType;
        entityType.Client.Connect();

        this.joiningRoom = false;
    }

    public override void Execute(GameController entityType)
    {
        if (!this.joiningRoom && entityType.Client.State == ExitGames.Client.Photon.LoadBalancing.ClientState.JoinedLobby)
        {
            this.joiningRoom = true;
            entityType.Client.OpJoinRandomRoom(null, 0);
        }
    }

    public override void Exit(GameController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(GameController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class GameState_BeforeStartGame : State<GameController>
{
    #region Static Fields

    private static GameState_BeforeStartGame instance;

    #endregion

    #region Public Methods and Operators

    public static GameState_BeforeStartGame Instance()
    {
        return instance ?? (instance = new GameState_BeforeStartGame());
    }

    public override void Enter(GameController entityType)
    {
        entityType.GetFSM().ChangeState(GameState_StartGame.Instance());
    }

    public override void Execute(GameController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(GameController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(GameController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class GameState_StartGame : State<GameController>
{
    #region Static Fields

    private static GameState_StartGame instance;

    #endregion

    #region Public Methods and Operators

    public static GameState_StartGame Instance()
    {
        return instance ?? (instance = new GameState_StartGame());
    }

    public override void Enter(GameController entityType)
    {
        entityType.StartGame();
    }

    public override void Execute(GameController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(GameController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(GameController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class GameState_GameOver : State<GameController>
{
    #region Static Fields

    private static GameState_GameOver instance;

    #endregion

    #region Public Methods and Operators

    public static GameState_GameOver Instance()
    {
        return instance ?? (instance = new GameState_GameOver());
    }

    public override void Enter(GameController entityType)
    {
        base.Enter(entityType);
    }

    public override void Execute(GameController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(GameController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(GameController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}