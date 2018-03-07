#region

using UnityEngine;

#endregion

public class RoadBlockController : BaseGameEntity
{
    #region Fields

    private float currentHp;

    private tk2dSlicedSprite hpBarSprite;
	
	private float hpBarLength;

    private StateMachine<RoadBlockController> m_PStateMachine;

    public tk2dSpriteAnimator SelfAnimator { get; set; }

    #endregion

    #region Public Properties

    public float CurrentHp
    {
        get
        {
            return this.currentHp;
        }
        set
        {
            this.currentHp = value;
            this.RefreshHpBar();
        }
    }

    public int TotalHp { get; set; }

    #endregion

    #region Public Methods and Operators

    public StateMachine<RoadBlockController> GetFSM()
    {
        return this.m_PStateMachine;
    }

    public override bool HandleMessage(Telegram telegram)
    {
        return this.m_PStateMachine.HandleMessage(telegram);
    }

    #endregion

    #region Methods

    private void RefreshHpBar()
    {
        if (this.hpBarSprite == null)
        {
            Transform hpBarTran = this.transform.FindChild("HpBar");
            this.hpBarSprite = hpBarTran.gameObject.GetComponent<tk2dSlicedSprite>();			
		}
		else
		{
			this.hpBarSprite.dimensions = new Vector2(this.CurrentHp/this.TotalHp*this.hpBarLength, this.hpBarSprite.dimensions.y);
		}
    }

    private void Start()
    {
        this.SelfAnimator = this.gameObject.GetComponent<tk2dSpriteAnimator>();
		this.hpBarLength = 400;

        this.m_PStateMachine = new StateMachine<RoadBlockController>(this);
        this.m_PStateMachine.SetCurrentState(RoadBlock_StateBuilding.Instance());
        this.m_PStateMachine.SetGlobalState(RoadBlock_GlobalState.Instance());
    }

    private void Update()
    {
        if (this.m_PStateMachine != null)
        {
            this.m_PStateMachine.SMUpdate();
        }
    }

    public void TakeDamage(float damage)
    {
        if (this.CurrentHp <= damage)
        {
            this.CurrentHp = 0;
            this.m_PStateMachine.ChangeState(RoadBlock_StateDestroy.Instance());
        }
        else
        {
            this.CurrentHp -= damage;
        }
    }

	public void ResetHp()
	{
		this.CurrentHp = this.TotalHp;
	}
    #endregion
}