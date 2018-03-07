#region

using UnityEngine;

#endregion

public class RoadBlock_GlobalState : State<RoadBlockController>
{
    #region Public Methods and Operators

    public static RoadBlock_GlobalState Instance()
    {
        return new RoadBlock_GlobalState();
    }

    public override void Enter(RoadBlockController entityType)
    {
        base.Enter(entityType);
    }

    public override void Execute(RoadBlockController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(RoadBlockController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage ( RoadBlockController entityType, Telegram telegram )
    {
        if (telegram.Msg == FSMessageType.FSMessageAttack)
        {
            if (telegram.Parameters.ContainsKey("Damage"))
            {
                entityType.TakeDamage((float)telegram.Parameters["Damage"]);
                return true;
            }
        }
        return false;
    }

    #endregion
}

public class RoadBlock_StateBuilding : State<RoadBlockController>
{
    #region Public Methods and Operators

    public static RoadBlock_StateBuilding Instance()
    {
        return new RoadBlock_StateBuilding();
    }

    public override void Enter(RoadBlockController entityType)
    {
        entityType.SelfAnimator.Play("Place");
        entityType.SelfAnimator.AnimationCompleted =
            delegate { entityType.GetFSM().ChangeState(RoadBlock_StateBuilt.Instance()); };
    }

    public override void Execute(RoadBlockController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(RoadBlockController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage ( RoadBlockController entityType, Telegram telegram )
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class RoadBlock_StateBuilt : State<RoadBlockController>
{
    #region Public Methods and Operators

    public static RoadBlock_StateBuilt Instance()
    {
        return new RoadBlock_StateBuilt();
    }

    public override void Enter(RoadBlockController entityType)
    {
        base.Enter(entityType);
    }

    public override void Execute(RoadBlockController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(RoadBlockController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(RoadBlockController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class RoadBlock_StateDestroy : State<RoadBlockController>
{
    #region Public Methods and Operators

    public static RoadBlock_StateDestroy Instance()
    {
        return new RoadBlock_StateDestroy();
    }

    public override void Enter(RoadBlockController entityType)
    {
        Object.Destroy(entityType.gameObject);
    }

    public override void Execute(RoadBlockController entityType)
    {
        
    }

    public override void Exit(RoadBlockController entityType)
    {
        
    }

    public override bool OnMessage(RoadBlockController entityType, Telegram telegram)
    {
        return false;
    }

    #endregion
}