#region

using System.ComponentModel;

using UnityEngine;

#endregion

public class BuildingController : BaseGameEntity
{
    #region Fields

    private Building _building;

    private Transform _myTransform;

    private tk2dSprite _selfSprite;
	
	private tk2dSlicedSprite hpBarSprite;
	
	private float hpbarLength;

    private bool menuShowing;

    private GameObject buildingMenu;

    public GameSceneController gameSceneController;

    private StateMachine<BuildingController> m_PStateMachine;

    #endregion

    #region Public Properties

    public Building Building
    {
        get
        {
            return this._building;
        }
        set
        {
            this._building = value;
            this.InitBuilding();
        }
    }

    public int DispatchIntervalLevel1 { get; set; }
    public int DispatchIntervalLevel2 { get; set; }

    public Transform MyTransform
    {
        get
        {
            if(this._myTransform == null)
				this._myTransform = this.gameObject.transform;
			return this._myTransform;
        }
        set
        {
            this._myTransform = value;
        }
    }

    public tk2dSprite SelfSprite
    {
        get
        {
            return this._selfSprite ?? (this._selfSprite = this.gameObject.GetComponent<tk2dSprite>());
        }
        set
        {
            this._selfSprite = value;
        }
    }

    #endregion

    #region Public Methods and Operators

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    public StateMachine<BuildingController> GetFSM()
    {
        return this.m_PStateMachine;
    }

    public override bool HandleMessage(Telegram telegram)
    {
        return this.m_PStateMachine.HandleMessage(telegram);
    }
	
	public void TakeDamage(Damage damage)
	{
        if (this.Building.CurrentHp <= damage.DamageValue)
        {
            this.Building.CurrentHp = 0;
			if(!this.m_PStateMachine.CurrentState().GetType().IsInstanceOfType(typeof(Building_StateBeforeDestroy)) 
				&& !this.m_PStateMachine.CurrentState().GetType().IsInstanceOfType(typeof(Building_StateDestroy)))
			{
				this.m_PStateMachine.ChangeState(Building_StateBeforeDestroy.Instance());
			}
		}
        else
        {
            this.Building.CurrentHp -= damage.DamageValue;
        }
        this.RefreshHpBar();
	}

    #endregion

    #region Methods

    private void InitBuilding()
    {
		this.hpbarLength = 600;
        this.menuShowing = false;
        this.gameSceneController = GameObject.Find("GameSceneController").GetComponent<GameSceneController>();

        if (this.Building != null)
        {
            this.DispatchIntervalLevel1 = this.Building.ProducedTimeLevel1;
            this.DispatchIntervalLevel2 = this.Building.ProducedTimeLevel2;

            this.m_PStateMachine = new StateMachine<BuildingController>(this);
            this.m_PStateMachine.SetCurrentState(Building_StateBeforeBuilt.Instance());
            this.m_PStateMachine.SetGlobalState(Building_GlobalState.Instance());
        }
    }

    private void Update()
    {
        if (this.m_PStateMachine != null)
        {
            this.m_PStateMachine.SMUpdate();
        }
    }
	
	private void RefreshHpBar()
    {
        if (this.hpBarSprite == null)
        {
            Transform hpBarTran = this.transform.FindChild("HpBar");
            this.hpBarSprite = hpBarTran.gameObject.GetComponent<tk2dSlicedSprite>();
        }
		else
		{
			this.hpBarSprite.dimensions = new Vector2(this.Building.CurrentHp/this.Building.TotalHp*this.hpbarLength, this.hpBarSprite.dimensions.y);
		}
    }

    void OnFingerDown ( FingerDownEvent e )
    {
        if (e.Selection == this.gameObject)
        {
            if (!this.menuShowing && this.Building.FactionType == this.gameSceneController.MyFactionType)
            {
                this.menuShowing = true;
                if (this.buildingMenu == null)
                {
                    this.buildingMenu = (GameObject)Instantiate(Resources.Load("UI/BuildingMenu"));
                    this.buildingMenu.name = "BuildingMenu";
                    this.buildingMenu.transform.parent = GameObject.Find("PanelRoot").transform;
                    this.buildingMenu.transform.localScale = new Vector3(1, 1, 1);
                    this.buildingMenu.transform.localPosition = this.WorldPosToNGUIPos(e.Finger.Position);

                    if (this.Building.MaxLevel == BuildingLevel.BuildingLevel1)
                    {
                        UIImageButton upgradeButton = this.buildingMenu.transform.FindChild("UpgradeButton").gameObject.GetComponent<UIImageButton>();
                        upgradeButton.isEnabled = false;
                    }

                    UIEventListener.Get(this.buildingMenu.transform.FindChild("RepairButton").gameObject).onClick =
                        HandleBuildingMenuEvent;
                    UIEventListener.Get(this.buildingMenu.transform.FindChild("UpgradeButton").gameObject).onClick =
                        HandleBuildingMenuEvent;
                    UIEventListener.Get(this.buildingMenu.transform.FindChild("SaleButton").gameObject).onClick =
                        HandleBuildingMenuEvent;
                }
                this.buildingMenu.SetActive(true);
            }
        }
        else
        {
            if (this.buildingMenu != null)
            {
                this.buildingMenu.SetActive(false);
                this.menuShowing = false;
            }
        }
    }

    private Vector3 WorldPosToNGUIPos(Vector3 pos)
    {
        return new Vector3(pos.x - Screen.width/2, pos.y - Screen.height/2, pos.z);
    }

    private void HandleBuildingMenuEvent(GameObject evObj)
    {
        switch (evObj.name)
        {
            case "SaleButton":
                {

                }
                break;
            case "UpgradeButton":
                {
                    if (this.UpgradeBuilding())
                    {
                        evObj.GetComponent<UIImageButton>().isEnabled = false;
                        GameController gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();
                        if (gameCtrl.GameType == GameType.PVP)
                        {
                            gameCtrl.Client.SendUpgradeBuilding(this.Building.BuildingId);
                        }
                    }
                }
                break;
            case "Repair":
                {

                }
                break;
        }
    }

    public bool UpgradeBuilding()
    {
        if ((int)this.Building.MaxLevel > (int)this.Building.CurrentLevel
            && this.Building.CurrentLevel == BuildingLevel.BuildingLevel1)
        {
            int dValue = this.gameSceneController.CoinCount - this.Building.CoinCostLevel2;
            if (dValue >= 0)
            {
                this.gameSceneController.CoinCount = dValue;
                this.Building.CurrentLevel = BuildingLevel.BuildingLevel2;
                return true;
            }
        }
        return false;
    }

    #endregion
}