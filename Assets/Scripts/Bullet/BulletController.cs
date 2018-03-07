using UnityEngine;

public class BulletController : BaseGameEntity
{
    #region Fields

    public BaseGameEntity Target { get; set; }

    public float MoveSpeed { get; set; }

    public Transform MyTransform;

    public BulletType BulletType { get; set; }

    public tk2dSprite SelfSprite;

    //private int chainLightningLength = 32;

    //public float chainLightningToScale;

    private StateMachine<BulletController> m_PStateMachine;

    #endregion

    #region Public Methods and Operators

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    public StateMachine<BulletController> GetFSM()
    {
        return this.m_PStateMachine;
    }

    public override bool HandleMessage(Telegram telegram)
    {
        return this.m_PStateMachine.HandleMessage(telegram);
    }

    #endregion

    #region Methods

    private void Start()
    {
        this.SetupMoveSpeed();
        this.MyTransform = this.transform;
        this.SetRotation();
        this.SelfSprite = this.GetComponent<tk2dSprite>();
        //if (this.BulletType == BulletType.ChainLightning)
        //{
        //    tk2dSpriteAnimator animator = this.gameObject.AddComponent<tk2dSpriteAnimator>();
        //    animator.Library =
        //        Resources.Load("Animation/ActorSkillEffectsAnimation", typeof(tk2dSpriteAnimation)) as
        //        tk2dSpriteAnimation;
        //    animator.Play("ChainLightningA");

        //    float distance = Vector3.Distance(this.MyTransform.position, this.Target.transform.position);
            //this.chainLightningToScale = Mathf.Max(distance / this.chainLightningLength, 1f);
       // }
       // else
        //{
            string spriteName = string.Empty + this.BulletType;
            this.SelfSprite.SetSprite(spriteName);
        //}

        this.m_PStateMachine = new StateMachine<BulletController>(this);
        this.m_PStateMachine.SetCurrentState(BulletState_MoveToTarget.Instance());
        this.m_PStateMachine.SetGlobalState(Bullet_GlobalState.Instance());
    }

    private void Update()
    {
        if (this.m_PStateMachine != null)
        {
            this.m_PStateMachine.SMUpdate();
        }
    }

    private void SetupMoveSpeed()
    {
        switch (this.BulletType)
        {
            case BulletType.Line_White:
                this.MoveSpeed = 400;
                break;
           case BulletType.Shell:
                this.MoveSpeed = 200;
                break;
           case BulletType.Magic_GryphonRider:
                this.MoveSpeed = 300;
                break;
           case BulletType.Magic_Pastor:
                this.MoveSpeed = 300;
                break;
            case BulletType.Sphere_Warlock:
                this.MoveSpeed = 300;
                break;
            default:
                this.MoveSpeed = 200;
                break;
        }
    }

    private void SetRotation()
    {
        if (this.Target != null)
        {
            Vector3 targetDirection = (this.Target.transform.position - this.MyTransform.position).normalized;
            Vector3 xPositiveDirection = new Vector3(1, 0, 0); 
            Quaternion newQuaternion = Quaternion.Euler(0, 0, 0);
            newQuaternion.eulerAngles = new Vector3(0, 0, Mathf.Acos(Vector3.Dot(xPositiveDirection.normalized, targetDirection.normalized))*Mathf.Rad2Deg);
            this.MyTransform.rotation = newQuaternion;
        }
    }

    #endregion
}