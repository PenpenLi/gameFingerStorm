public class ActorAttack
{
    #region Constructors and Destructors

    public ActorAttack(ActorAttackType attackType, int range, int dps)
    {
        this.ActorAttackType = attackType;
        this.AttackRange = range;
        this.ViewDistance = 200;
        this.Dps = dps;
    }

    #endregion

    #region Public Properties

    public ActorAttackType ActorAttackType { get; set; } //攻击类型

    public int AttackRange { get; set; } //攻击范围

    public int ViewDistance { get; set; } //视野范围

    public int Dps { get; set; }  //每秒输出

    #endregion

}