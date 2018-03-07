#region

using UnityEngine;

#endregion

public class GameController : BaseGameEntity
{
    #region Fields

    public UIEventController EventController;

    public GameSceneController GameSceneController;

    public UIViewController ViewController;

    private StateMachine<GameController> m_PStateMachine;

    #endregion

    #region Public Properties

    public FSClient Client { get; set; }

    public GameType GameType { get; set; }

    public FactionType MyFactionType { get; set; }

    public RaceType MyRaceType { get; set; }

    #endregion

    #region Public Methods and Operators

    public StateMachine<GameController> GetFSM()
    {
        return this.m_PStateMachine;
    }

    public override bool HandleMessage(Telegram telegram)
    {
        return this.m_PStateMachine.HandleMessage(telegram);
    }

    public void StartGame()
    {
        Transform raceSelect = GameObject.Find("HomePage").transform.FindChild("RaceSelect");
        if (raceSelect != null)
        {
            UIPopupList popupList = raceSelect.gameObject.GetComponent<UIPopupList>();
            if (popupList.value == "人族")
            {
                this.MyRaceType = RaceType.Terran;
            }
            else if (popupList.value == "兽族")
            {
                this.MyRaceType = RaceType.Orc;
            }
        }
        this.ViewController.DestroyHomePage(true);
        this.ViewController.DestroyShadowCover(true);
        GameObject gameSceneCtrl = (GameObject)Instantiate(Resources.Load("GameScene/GameSceneController"));
        gameSceneCtrl.transform.localPosition = new Vector3(0, 0, 0);
        gameSceneCtrl.name = "GameSceneController";
        this.GameSceneController = gameSceneCtrl.GetComponent<GameSceneController>();
        this.GameSceneController.GameController = this;
        this.GameSceneController.MyFactionType = this.MyFactionType;
        this.GameSceneController.MyRaceType = this.MyRaceType;
    }

    public void OnRaceSelect()
    {
        if (UIPopupList.current != null)
        {
            string raceType = UIPopupList.current.value;
            if (raceType == "人族")
            {
                this.MyRaceType = RaceType.Terran;
            }
            else if (raceType == "兽族")
            {
                this.MyRaceType = RaceType.Orc;
            }
        }
    }

    #endregion

    #region Methods

    private void Awake()
    {
        this.LoadGlobalConfig();

        CustomTypes.Register();
        this.MyRaceType = RaceType.Terran;
    }

    private void LoadGlobalConfig()
    {
        GameObject loadObj = new GameObject("LoadConfigOfLua");
        loadObj.AddComponent<LoadConfigOfLua>();
    }

    private void Start()
    {
        Application.runInBackground = true;

        this.m_PStateMachine = new StateMachine<GameController>(this);
        this.m_PStateMachine.SetCurrentState(GameState_HomePage.Instance());
        this.m_PStateMachine.SetGlobalState(GameState_GlobalState.Instance());
    }

    private void Update()
    {
        if (this.m_PStateMachine != null)
        {
            this.m_PStateMachine.SMUpdate();
        }
    }

    #endregion
}