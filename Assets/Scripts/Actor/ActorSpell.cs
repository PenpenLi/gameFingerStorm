#region

using UnityEngine;

#endregion

public class ActorSpell
{
    public ActorSpell(ActorSpellName spellName, ActorType actorType)
    {
        this.ActorSpellType = ActorSpellType.PassiveSpell;
        this.ActorSpellName = spellName;
        this.ReleaseInterval = 0;
        this.AttackRange = 0;
        this.DamageBonusPercent = 0f;
        this.DamageBonusPercentProbability = 0;
        this.IncreaseFriendlyForcesArmor = 0;
        this.Resurrection = false;
        this.StunDuration = 0;
        this.StunProbability = 0;
        this.AdditionalDamage = 0;
        this.AdditionalDamageProbability = 0;
        this.DirectDamage = 0;
        this.DirectDamageProbability = 0;
        this.SplashPercent = 0;
        this.EvasiveProbability = 0;
		this.ParryAttackType = ActorAttackType.Normal;
		this.ParryPercent = 0;
		this.BleedDuration = 0;
		this.BleedProbability = 0;
		this.BleedDps = 0;
		this.IncreaseOneFriendlyUnitHp = 0;

        switch (actorType)
        {
			case ActorType.Infantry:
                {
                    this.ParryAttackType = ActorAttackType.Pierce;
					this.ParryPercent = 30;
                    break;
                }
            case ActorType.Supporter:
                {
                    this.EvasiveProbability = 15;
                    break;
                }
            case ActorType.Sniper:
                {
                    this.DamageBonusPercent = 1.5f;
                    this.DamageBonusPercentProbability = 10;
                    break;
                }
            case ActorType.Marksman:
                {
                    this.DamageBonusPercent = 3;
                    this.DamageBonusPercentProbability = 40;
                    break;
                }
            case ActorType.HeavyGunner:
                {
                    this.AttackRange = 18;
                    this.SplashPercent = 50;
                    break;
                }
            case ActorType.MortarTeam:
                {
                    this.AttackRange = 40;
                    this.DirectDamage = 21;
                    this.ReleaseInterval = 3;
                    this.ActorSpellType = ActorSpellType.ActiveSpell;
                    break;
                }
            case ActorType.Warlock:
                {
                    this.AttackRange = 50;
                    this.DirectDamage = 27;
                    this.ReleaseInterval = 5;
                    this.ActorSpellType = ActorSpellType.ActiveSpell;
                    break;
                }
            case ActorType.GryphonRider:
                {
                    this.BleedProbability = 25;
					this.BleedDps = 15;
					this.BleedDuration = 3;
                    break;
                }
            case ActorType.SeniorGryphonRider:
                {
                    this.BleedProbability = 30;
					this.BleedDps = 20;
					this.BleedDuration = 5;
                    break;
                }
            case ActorType.Crusader:
                {
                        this.StunDuration = 2;
                        this.StunProbability = 20;
                        this.AdditionalDamage = 25;
                    break;
                }
            case ActorType.TemplarWarrior:
                {
                    this.StunDuration = 2;
					this.StunProbability = 25;
					this.AdditionalDamage = 30;
                    break;
                }
			case ActorType.Pastor:
                {
                    this.IncreaseOneFriendlyUnitHp = 300;
                    this.ReleaseInterval = 15;
                    this.ActorSpellType = ActorSpellType.ActiveSpell;
                    break;
                }
			case ActorType.Sage:
                {
                    this.DirectDamageProbability = 25;
					this.DirectDamage = 200;
                    break;
                }
			case ActorType.Knight:
                {
                    this.IncreaseFriendlyForcesArmor = 6;
					this.AttackRange = 160;
                    this.ReleaseInterval = 10;
                    break;
                }
			case ActorType.Paladin:
                {
                    this.IncreaseFriendlyForcesArmor = 9;
					this.AttackRange = 200;
                    this.ReleaseInterval = 8;
                    break;
                }
            case ActorType.Shaman:
                {
                    this.ReleaseInterval = 16;
                    break;
                }
            case ActorType.WitchDoctor:
                {
                    this.ReleaseInterval = 10;
                    break;
                }
            case ActorType.Raider:
                {
                    this.ReleaseInterval = 8;
                    break;
                }
            case ActorType.Catapult:
                {
                    this.ReleaseInterval = 3;
                    break;
                }
            case ActorType.SpiritWalker:
                {
                    this.ReleaseInterval = 10;
                    break;
                }
        }
    }

    #region Fields

    public ActorSpellType ActorSpellType { get; set; } //技能类型

    public ActorSpellName ActorSpellName { get; set; } //技能名称

    public int ReleaseInterval { get; set; } //释放间隔

    public GameObject AffectedObjects { get; set; } //受影响物体

    public int AttackRange { get; set; } //攻击范围

    public float DamageBonusPercent { get; set; } //伤害加成

    public int DamageBonusPercentProbability { get; set; } //伤害加成概率

    public int IncreaseFriendlyForcesArmor { get; set; } //增加友军护甲

    //public int IncreaseFriendlyForcesArmorDistance { get; set; } //增加友军护甲的影响范围

    public bool Resurrection { get; set; } //使目标单位复活

    public int StunDuration { get; set; } //眩晕持续时长

    public int StunProbability { get; set; } //眩晕几率

    public int AdditionalDamage { get; set; } //追加伤害

    public int AdditionalDamageProbability { get; set; } //追加伤害概率

    public int DirectDamage { get; set; } //直接伤害

    public int DirectDamageProbability { get; set; } //直接伤害几率

    public int SplashPercent { get; set; } //溅射伤害百分比

    public int EvasiveProbability { get; set; } //躲避几率
	
	public ActorAttackType ParryAttackType {get; set;} //格挡攻击类型
	
	public int ParryPercent {get;set;} //格挡百分比
	
	public int BleedDuration {get;set;} //流血持续时间
	
	public int BleedDps {get; set;} //流血每秒伤害
	
	public int BleedProbability {get;set;} //流血几率
	
	public int IncreaseOneFriendlyUnitHp {get; set;} //增加某友军单位血量
	
    #endregion
}