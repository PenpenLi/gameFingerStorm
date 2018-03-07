#region

using System.Security.Cryptography;
using System.Text;

using UnityEngine;

#endregion

public class Building_GlobalState : State<BuildingController>
{
    //private static Actor_GlobalState instance;

    #region Public Methods and Operators

    public static Building_GlobalState Instance()
    {
        //return instance ?? (instance = new Actor_GlobalState());
        return new Building_GlobalState();
    }

    public override void Enter(BuildingController entityType)
    {
        base.Enter(entityType);
    }

    public override void Execute(BuildingController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(BuildingController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(BuildingController entityType, Telegram telegram)
    {
        if (telegram.Msg == FSMessageType.FSMessageAttack)
        {
            if (telegram.Parameters.ContainsKey("Damage"))
            {
                entityType.TakeDamage((Damage)telegram.Parameters["Damage"]);
                return true;
            }
        }
        return false;
    }

    #endregion
}

public class Building_StateBeforeBuilt : State<BuildingController>
{
    #region Public Methods and Operators

    public static Building_StateBeforeBuilt Instance()
    {
        return new Building_StateBeforeBuilt();
    }

    public override void Enter(BuildingController entityType)
    {
        tk2dSpriteCollectionData data =
            tk2dSystem.LoadResourceByName<tk2dSpriteCollectionData>(entityType.Building.Race + "BuildingsCollection");
            
        StringBuilder spriteName = new StringBuilder(string.Empty);
        spriteName.Append(entityType.Building.BuildingType);
        spriteName.Append("_");
        spriteName.Append(entityType.Building.FactionType);
        entityType.SelfSprite.SetSprite(data, spriteName.ToString());

        entityType.GetFSM().ChangeState(Building_StateBuilding.Instance());
    }

    public override void Execute(BuildingController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(BuildingController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(BuildingController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class Building_StateUpgrade : State<BuildingController>
{
    #region Public Methods and Operators

    public static Building_StateUpgrade Instance ()
    {
        return new Building_StateUpgrade();
    }

    public override void Enter(BuildingController entityType)
    {
        if (entityType.Building.CurrentLevel == BuildingLevel.BuildingLevel1)
        {
            entityType.Building.CurrentLevel = BuildingLevel.BuildingLevel2;
            entityType.GetFSM().ChangeState(Building_StateBeforeBuilt.Instance());
        }
        else
        {
            entityType.GetFSM().ChangeState(Building_StateDispatching.Instance());
        }
    }

    public override void Execute(BuildingController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(BuildingController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(BuildingController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class Building_StateBuilding : State<BuildingController>
{
    #region Public Methods and Operators

    public static Building_StateBuilding Instance ()
    {
        return new Building_StateBuilding();
    }

    public override void Enter ( BuildingController entityType )
    {
        entityType.GetFSM().ChangeState(Building_StateDispatching.Instance());
    }

    public override void Execute ( BuildingController entityType )
    {
        base.Execute(entityType);
    }

    public override void Exit ( BuildingController entityType )
    {
        base.Exit(entityType);
    }

    public override bool OnMessage ( BuildingController entityType, Telegram telegram )
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class Building_StateDispatching : State<BuildingController>
{
    #region Fields

    private int dispatchIntervalLevel1;

    private float dispatchIntervalCounterLevel1;

    private int dispatchIntervalLevel2;

    private float dispatchIntervalCounterLevel2;

    #endregion

    #region Public Methods and Operators

    public static Building_StateDispatching Instance()
    {
        return new Building_StateDispatching();
    }

    public override void Enter(BuildingController entityType)
    {
        this.dispatchIntervalLevel1 = entityType.DispatchIntervalLevel1;
        this.dispatchIntervalCounterLevel1 = 0f;
        this.dispatchIntervalLevel2 = entityType.DispatchIntervalLevel2;
        this.dispatchIntervalCounterLevel2 = 0f;
    }

    public override void Execute(BuildingController entityType)
    {
        if (entityType.Building.IsMainCity)
        {
            return;
        }
        if (this.dispatchIntervalLevel1 != entityType.DispatchIntervalLevel1)
        {
            this.dispatchIntervalLevel1 = entityType.DispatchIntervalLevel1;
            this.dispatchIntervalCounterLevel1 = 0f;
        }
        else
        {
            this.dispatchIntervalCounterLevel1 += Time.deltaTime;
            if (this.dispatchIntervalCounterLevel1 >= this.dispatchIntervalLevel1)
            {
                //if(entityType.Building.FactionType == FactionType.Red)
                    this.DispatchActor(entityType, BuildingLevel.BuildingLevel1);
                this.dispatchIntervalCounterLevel1 = 0f;
            }
        }

        if (entityType.Building.CurrentLevel == BuildingLevel.BuildingLevel2)
        {
            if (this.dispatchIntervalLevel2 != entityType.DispatchIntervalLevel2)
            {
                this.dispatchIntervalLevel2 = entityType.DispatchIntervalLevel2;
                this.dispatchIntervalCounterLevel2 = 0f;
            }
            else
            {
                this.dispatchIntervalCounterLevel2 += Time.deltaTime;
                if (this.dispatchIntervalCounterLevel2 >= this.dispatchIntervalLevel2)
                {
                    this.DispatchActor(entityType, BuildingLevel.BuildingLevel2);
                    this.dispatchIntervalCounterLevel2 = 0f;
                }
            }
        }
    }

    public override void Exit(BuildingController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(BuildingController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion

    #region Methods

    private void DispatchActor(BuildingController entityType, BuildingLevel buildingLevel)
    {
        ActorsManager.GetInstance()
            .CreateNewActor(
                entityType.Building.FactionType, entityType.Building.Race,
                buildingLevel == BuildingLevel.BuildingLevel1 ? entityType.Building.ProducedActorTypeLevel1 : entityType.Building.ProducedActorTypeLevel2,
                entityType.MyTransform.position);
    }

    #endregion
}

public class Building_StateBeforeDestroy : State<BuildingController>
{
    #region Public Methods and Operators

    public static Building_StateBeforeDestroy Instance()
    {
        return new Building_StateBeforeDestroy();
    }

    public override void Enter(BuildingController entityType)
    {
        /*if (!entityType.gameSceneController.IsArmageddon && entityType.Building.IsMainCity)
        {
            GameController gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();
            if(gameCtrl.GameType == GameType.PVP)
                gameCtrl.Client.SendGameResult();
            entityType.gameSceneController.ShowGameResult(entityType.Building.FactionType != gameCtrl.MyFactionType);
        }*/
        entityType.GetFSM().ChangeState(Building_StateDestroy.Instance());
    }

    public override void Execute(BuildingController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(BuildingController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(BuildingController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class Building_StateDestroy : State<BuildingController>
{
    #region Public Methods and Operators

    public static Building_StateDestroy Instance()
    {
        return new Building_StateDestroy();
    }

    public override void Enter(BuildingController entityType)
    {
		BuildingsManager.GetInstance().DestroyBuilding(entityType.gameObject);
        //Object.Destroy(entityType.gameObject);
    }

    public override void Execute(BuildingController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(BuildingController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(BuildingController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}