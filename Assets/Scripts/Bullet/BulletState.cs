using System.Reflection;

using UnityEngine;

public class Bullet_GlobalState : State<BulletController>
{
    #region Public Methods and Operators

    public static Bullet_GlobalState Instance()
    {
        return new Bullet_GlobalState();
    }

    public override void Enter(BulletController entityType)
    {
        base.Enter(entityType);
    }

    public override void Execute(BulletController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(BulletController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(BulletController entityType, Telegram telegram)
    {
        return false;
    }

    #endregion
}

public class BulletState_MoveToTarget : State<BulletController>
{
    #region Public Methods and Operators

    public static BulletState_MoveToTarget Instance()
    {
        return new BulletState_MoveToTarget();
    }

    public override void Enter(BulletController entityType)
    {
        base.Enter(entityType);
    }

    public override void Execute(BulletController entityType)
    {
        if (entityType.Target != null)
        {
           // if (entityType.BulletType == BulletType.ChainLightning)
           // {
           //     if (entityType.SelfSprite != null)
           //     {
           //         if (entityType.SelfSprite.scale.x - entityType.chainLightningToScale > -0.05f || entityType.SelfSprite.scale.x >= entityType.chainLightningToScale)
           //         {
           //             entityType.GetFSM().ChangeState(BulletState_Arrival.Instance());
           //         }
           //         else
           //         {
            //            entityType.SelfSprite.scale = new Vector3(entityType.SelfSprite.scale.x + Time.deltaTime * entityType.MoveSpeed, 1f, 1f);
           //         }
          //      }
          //  }
          //  else
         //   {
                Vector3 moveDistance = entityType.MoveSpeed * Time.deltaTime
                               * (entityType.Target.transform.position - entityType.MyTransform.position).normalized;
                entityType.MyTransform.Translate(moveDistance, Space.World);

                if ((entityType.Target.transform.position - entityType.MyTransform.position).sqrMagnitude <= 1)
                {
                    entityType.GetFSM().ChangeState(BulletState_Arrival.Instance());
                }
          //  }
        }
        else
        {
            entityType.GetFSM().ChangeState(BulletState_Destroy.Instance());
        }
    }

    public override void Exit(BulletController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(BulletController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class BulletState_Arrival : State<BulletController>
{
    #region Public Methods and Operators

    public static BulletState_Arrival Instance ()
    {
        return new BulletState_Arrival();
    }

    public override void Enter ( BulletController entityType )
    {
        if (entityType.Target != null && entityType.Target is ActorController)
        {
            if (entityType.BulletType == BulletType.SiegeStone)
            {
                GameObject effect = (GameObject)Object.Instantiate(Resources.Load("GameScene/ActorSkillEffect"));
                effect.transform.parent = entityType.Target.transform;
                effect.transform.localPosition = entityType.Target.transform.localScale.y == 0 ? new Vector3(10, 0, -1) : new Vector3(10, 0, 1);
                tk2dSpriteAnimator animator = effect.GetComponent<tk2dSpriteAnimator>();
                animator.Play("FireBomb");
                animator.AnimationCompleted = delegate
                    {
                        Object.Destroy(effect);
                    };
            }
        }
        entityType.GetFSM().ChangeState(BulletState_Destroy.Instance());
    }

    public override void Execute ( BulletController entityType )
    {
        base.Execute(entityType);
    }

    public override void Exit ( BulletController entityType )
    {
        base.Exit(entityType);
    }

    public override bool OnMessage ( BulletController entityType, Telegram telegram )
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class BulletState_Destroy : State<BulletController>
{
    #region Public Methods and Operators

    public static BulletState_Destroy Instance()
    {
        return new BulletState_Destroy();
    }

    public override void Enter(BulletController entityType)
    {
        entityType.DestroySelf();
    }

    public override void Execute(BulletController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(BulletController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(BulletController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}