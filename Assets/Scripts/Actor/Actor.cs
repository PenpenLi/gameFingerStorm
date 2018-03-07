#region

using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;

using UnityEngine;

#endregion

public class Actor
{
    #region Constructors and Destructors

    public Actor(int actorId, RaceType raceType, ActorType type, FactionType faction)
    {
        this.ActorId = actorId;
        this.ActorType = type;
        this.FactionType = faction;
        this.RaceType = raceType;
        this.ActorArmor = ActorsConfig.GetActorArmor(this.RaceType, this.ActorType);
        this.ActorAttack = ActorsConfig.GetActorAttack(this.RaceType, this.ActorType);
        this.AttackAirForce = ActorsConfig.GetAttackAirForce(this.RaceType, this.ActorType);
        this.IsAirForce = ActorsConfig.GetIsAirForce(this.RaceType, this.ActorType);
        this.TotalHp = ActorsConfig.GetHp(this.RaceType, this.ActorType);
        this.ActorLevel = ActorsConfig.GetActorLevel(this.RaceType, this.ActorType);
        this.SpellDictionary = ActorsConfig.GetSpellDictionary(this.RaceType, this.ActorType);

        this.CurrentHp = this.TotalHp;
    }

    #endregion

    #region Public Properties

    public ActorArmor ActorArmor { get; set; }

    public ActorAttack ActorAttack { get; set; }

    public int ActorId { get; set; }

    public ActorType ActorType { get; set; }

    public FactionType FactionType { get; set; }

    public bool AttackAirForce { get; set; }

    public bool IsAirForce { get; set; }

    public float TotalHp { get; set; }

    public float CurrentHp { get; set; }

    public ActorLevel ActorLevel { get; set; }

    public RaceType RaceType { get; set; }

    public Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary { get; set; }

    #endregion

    #region Methods

    private ActorAttack LoadActorAttackFromConfig()
    {
        ActorAttackType attackType;
        string attackTypeStr;
        int attackRange;
        int dps;
        switch (this.ActorType)
        {
            case ActorType.Infantry:
                {
                    attackTypeStr = GlobalConfig.TerranActorInfantryAttackType;
                    attackRange = GlobalConfig.TerranActorInfantryAttackRange;
                    dps = GlobalConfig.TerranActorInfantryDps;
                    break;
                }
            case ActorType.Supporter:
                {
                    attackTypeStr = GlobalConfig.TerranActorSupporterAttackType;
                    attackRange = GlobalConfig.TerranActorSupporterAttackRange;
                    dps = GlobalConfig.TerranActorSupporterDps;
                    break;
                }
            case ActorType.Sniper:
                {
                    attackTypeStr = GlobalConfig.TerranActorSniperAttackType;
                    attackRange = GlobalConfig.TerranActorSniperAttackRange;
                    dps = GlobalConfig.TerranActorSniperDps;
                    break;
                }
            case ActorType.Marksman:
                {
                    attackTypeStr = GlobalConfig.TerranActorMarksmanAttackType;
                    attackRange = GlobalConfig.TerranActorMarksmanAttackRange;
                    dps = GlobalConfig.TerranActorMarksmanDps;
                    break;
                }
            case ActorType.HeavyGunner:
                {
                    attackTypeStr = GlobalConfig.TerranActorHeavyGunnerAttackType;
                    attackRange = GlobalConfig.TerranActorHeavyGunnerAttackRange;
                    dps = GlobalConfig.TerranActorHeavyGunnerDps;
                    break;
                }
            case ActorType.MortarTeam:
                {
                    attackTypeStr = GlobalConfig.TerranActorMortarTeamAttackType;
                    attackRange = GlobalConfig.TerranActorMortarTeamAttackRange;
                    dps = GlobalConfig.TerranActorMortarTeamDps;
                    break;
                }
            case ActorType.Warlock:
                {
                    attackTypeStr = GlobalConfig.TerranActorWarlockAttackType;
                    attackRange = GlobalConfig.TerranActorWarlockAttackRange;
                    dps = GlobalConfig.TerranActorWarlockDps;
                    break;
                }
            case ActorType.GryphonRider:
                {
                    attackTypeStr = GlobalConfig.TerranActorGryphonRiderAttackType;
                    attackRange = GlobalConfig.TerranActorGryphonRiderAttackRange;
                    dps = GlobalConfig.TerranActorGryphonRiderDps;
                    break;
                }
            case ActorType.SeniorGryphonRider:
                {
                    attackTypeStr = GlobalConfig.TerranActorSeniorGryphonRiderAttackType;
                    attackRange = GlobalConfig.TerranActorSeniorGryphonRiderAttackRange;
                    dps = GlobalConfig.TerranActorSeniorGryphonRiderDps;
                    break;
                }
            case ActorType.Crusader:
                {
                    attackTypeStr = GlobalConfig.TerranActorCrusaderAttackType;
                    attackRange = GlobalConfig.TerranActorCrusaderAttackRange;
                    dps = GlobalConfig.TerranActorCrusaderDps;
                    break;
                }
            case ActorType.TemplarWarrior:
                {
                    attackTypeStr = GlobalConfig.TerranActorTemplarWarriorAttackType;
                    attackRange = GlobalConfig.TerranActorTemplarWarriorAttackRange;
                    dps = GlobalConfig.TerranActorTemplarWarriorDps;
                    break;
                }
            default:
                {
                    attackTypeStr = "";
                    attackRange = 0;
                    dps = 0;
                    break;
                }
        }
        switch (attackTypeStr)
        {
            case "Normal":
                attackType = ActorAttackType.Normal;
                break;
            case "Pierce":
                attackType = ActorAttackType.Pierce;
                break;
            case "Siege":
                attackType = ActorAttackType.Siege;
                break;
            case "Confuse":
                attackType = ActorAttackType.Confuse;
                break;
            case "Magic":
                attackType = ActorAttackType.Magic;
                break;
            case "HeroAttack":
                attackType = ActorAttackType.HeroAttack;
                break;
            default:
                attackType = ActorAttackType.Normal;
                break;
        }
        return new ActorAttack(attackType, attackRange, dps);
    }

    private ActorArmor LoadArmorFromConfig()
    {
        ActorArmorType armorType;
        string armorTypeStr;
        int armorAmount;
        switch (this.ActorType)
        {
            case ActorType.Infantry:
                {
                    armorTypeStr = GlobalConfig.TerranActorInfantryArmorType;
                    armorAmount = GlobalConfig.TerranActorInfantryDef;
                    break;
                }
            case ActorType.Supporter:
                {
                    armorTypeStr = GlobalConfig.TerranActorSupporterArmorType;
                    armorAmount = GlobalConfig.TerranActorSupporterDef;
                    break;
                }
            case ActorType.Sniper:
                {
                    armorTypeStr = GlobalConfig.TerranActorSniperArmorType;
                    armorAmount = GlobalConfig.TerranActorSniperDef;
                    break;
                }
            case ActorType.Marksman:
                {
                    armorTypeStr = GlobalConfig.TerranActorMarksmanArmorType;
                    armorAmount = GlobalConfig.TerranActorMarksmanDef;
                    break;
                }
            case ActorType.HeavyGunner:
                {
                    armorTypeStr = GlobalConfig.TerranActorHeavyGunnerArmorType;
                    armorAmount = GlobalConfig.TerranActorHeavyGunnerDef;
                    break;
                }
            case ActorType.MortarTeam:
                {
                    armorTypeStr = GlobalConfig.TerranActorMortarTeamArmorType;
                    armorAmount = GlobalConfig.TerranActorMortarTeamDef;
                    break;
                }
            case ActorType.Warlock:
                {
                    armorTypeStr = GlobalConfig.TerranActorWarlockArmorType;
                    armorAmount = GlobalConfig.TerranActorWarlockDef;
                    break;
                }
            case ActorType.GryphonRider:
                {
                    armorTypeStr = GlobalConfig.TerranActorGryphonRiderArmorType;
                    armorAmount = GlobalConfig.TerranActorGryphonRiderDef;
                    break;
                }
            case ActorType.SeniorGryphonRider:
                {
                    armorTypeStr = GlobalConfig.TerranActorSeniorGryphonRiderArmorType;
                    armorAmount = GlobalConfig.TerranActorSeniorGryphonRiderDef;
                    break;
                }
            case ActorType.Crusader:
                {
                    armorTypeStr = GlobalConfig.TerranActorCrusaderArmorType;
                    armorAmount = GlobalConfig.TerranActorCrusaderDef;
                    break;
                }
            case ActorType.TemplarWarrior:
                {
                    armorTypeStr = GlobalConfig.TerranActorTemplarWarriorArmorType;
                    armorAmount = GlobalConfig.TerranActorTemplarWarriorDef;
                    break;
                }
            default:
                {
                    armorTypeStr = "";
                    armorAmount = 0;
                    break;
                }
        }
        switch (armorTypeStr)
        {
            case "LightArmor":
                armorType = ActorArmorType.LightArmor;
                break;
            case "HeroArmor":
                armorType = ActorArmorType.HeroArmor;
                break;
            case "HeavyArmor":
                armorType = ActorArmorType.HeavyArmor;
                break;
            default:
                armorType = ActorArmorType.None;
                break;
        }
        return new ActorArmor(armorType, armorAmount);
    }

    private void LoadLevelFromConfig ()
    {
        switch (this.ActorType)
        {
            case ActorType.Infantry:
                {
                    this.ActorLevel = ActorLevel.Normal;
                    break;
                }
            case ActorType.Supporter:
                {
                    this.ActorLevel = ActorLevel.Senior;
                    break;
                }
            case ActorType.Sniper:
                {
                    this.ActorLevel = ActorLevel.Normal;
                    break;
                }
            case ActorType.Marksman:
                {
                    this.ActorLevel = ActorLevel.Senior;
                    break;
                }
            case ActorType.HeavyGunner:
                {
                    this.ActorLevel = ActorLevel.Normal;
                    break;
                }
            case ActorType.MortarTeam:
                {
                    this.ActorLevel = ActorLevel.Senior;
                    break;
                }
            case ActorType.Warlock:
                {
                    this.ActorLevel = ActorLevel.Normal;
                    break;
                }
            case ActorType.GryphonRider:
                {
                    this.ActorLevel = ActorLevel.Normal;
                    break;
                }
            case ActorType.SeniorGryphonRider:
                {
                    this.ActorLevel = ActorLevel.Senior;
                    break;
                }
            case ActorType.Crusader:
                {
                    this.ActorLevel = ActorLevel.Normal;
                    break;
                }
            case ActorType.TemplarWarrior:
                {
                    this.ActorLevel = ActorLevel.Senior;
                    break;
                }
            default:
                {
                    this.ActorLevel = ActorLevel.Normal;
                    break;
                }
        }
    }

    private float LoadHpFromConfig()
    {
        switch (this.ActorType)
        {
            case ActorType.Infantry:
                {
                    this.CurrentHp = GlobalConfig.TerranActorInfantryHp;
                    return GlobalConfig.TerranActorInfantryHp;
                }
            case ActorType.Supporter:
                {
                    this.CurrentHp = GlobalConfig.TerranActorSupporterHp;
                    return GlobalConfig.TerranActorSupporterHp;
                }
            case ActorType.Sniper:
                {
                    this.CurrentHp = GlobalConfig.TerranActorSniperHp;
                    return GlobalConfig.TerranActorSniperHp;
                }
            case ActorType.Marksman:
                {
                    this.CurrentHp = GlobalConfig.TerranActorMarksmanHp;
                    return GlobalConfig.TerranActorMarksmanHp;
                }
            case ActorType.HeavyGunner:
                {
                    this.CurrentHp = GlobalConfig.TerranActorHeavyGunnerHp;
                    return GlobalConfig.TerranActorHeavyGunnerHp;
                }
            case ActorType.MortarTeam:
                {
                    this.CurrentHp = GlobalConfig.TerranActorMortarTeamHp;
                    return GlobalConfig.TerranActorMortarTeamHp;
                }
            case ActorType.Warlock:
                {
                    this.CurrentHp = GlobalConfig.TerranActorWarlockHp;
                    return GlobalConfig.TerranActorWarlockHp;
                }
            case ActorType.GryphonRider:
                {
                    this.CurrentHp = GlobalConfig.TerranActorGryphonRiderHp;
                    return GlobalConfig.TerranActorGryphonRiderHp;
                }
            case ActorType.SeniorGryphonRider:
                {
                    this.CurrentHp = GlobalConfig.TerranActorSeniorGryphonRiderHp;
                    return GlobalConfig.TerranActorSeniorGryphonRiderHp;
                }
            case ActorType.Crusader:
                {
                    this.CurrentHp = GlobalConfig.TerranActorCrusaderHp;
                    return GlobalConfig.TerranActorCrusaderHp;
                }
            case ActorType.TemplarWarrior:
                {
                    this.CurrentHp = GlobalConfig.TerranActorTemplarWarriorHp;
                    return GlobalConfig.TerranActorTemplarWarriorHp;
                }
            default:
                {
                    return 0;
                }
        }
    }

    private Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> LoadSpellsFromConfig ()
    {
        Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> dictionary = new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>();
        string spellStr;
        switch (this.ActorType)
        {
            case ActorType.Infantry:
                {
                    spellStr = GlobalConfig.TerranActorInfantrySpell;
                    break;
                }
            case ActorType.Supporter:
                {
                    spellStr = GlobalConfig.TerranActorSupporterSpell;
                    break;
                }
            case ActorType.Sniper:
                {
                    spellStr = GlobalConfig.TerranActorSniperSpell;
                    break;
                }
            case ActorType.Marksman:
                {
                    spellStr = GlobalConfig.TerranActorMarksmanSpell;
                    break;
                }
            case ActorType.HeavyGunner:
                {
                    spellStr = GlobalConfig.TerranActorHeavyGunnerSpell;
                    break;
                }
            case ActorType.MortarTeam:
                {
                    spellStr = GlobalConfig.TerranActorMortarTeamSpell;
                    break;
                }
            case ActorType.Warlock:
                {
                    spellStr = GlobalConfig.TerranActorWarlockSpell;
                    break;
                }
            case ActorType.GryphonRider:
                {
                    spellStr = GlobalConfig.TerranActorGryphonRiderSpell;
                    break;
                }
            case ActorType.SeniorGryphonRider:
                {
                    spellStr = GlobalConfig.TerranActorSeniorGryphonRiderSpell;
                    break;
                }
            case ActorType.Crusader:
                {
                    spellStr = GlobalConfig.TerranActorCrusaderSpell;
                    break;
                }
            case ActorType.TemplarWarrior:
                {
                    spellStr = GlobalConfig.TerranActorTemplarWarriorSpell;
                    break;
                }
            default:
                {
                    spellStr = string.Empty;
                    break;
                }
        }
        string[] spellArr = spellStr.Split('/');
        int length = spellArr.Length;
        for (int i = 0; i < length; i ++)
        {
            ActorSpell actorSpell;
            string spell = spellArr[i];
            switch (spell)
            {
                case "None":
                        actorSpell = new ActorSpell(ActorSpellName.None, this.ActorType);
                    break;
                case "Dodge":
                        actorSpell = new ActorSpell(ActorSpellName.Dodge, this.ActorType);
                    break;
                case "CirticalStrike":
                        actorSpell = new ActorSpell(ActorSpellName.CirticalStrike, this.ActorType);
                    break;
                case "HeadShot":
                    actorSpell = new ActorSpell(ActorSpellName.HeadShot, this.ActorType);
                    break;
                case "SplashDamage":
                    actorSpell = new ActorSpell(ActorSpellName.SplashDamage, this.ActorType);
                    break;
                case "MortarAttack":
                    actorSpell = new ActorSpell(ActorSpellName.MortarAttack, this.ActorType);
                    break;
                case "ArcaneExplosion":
                    actorSpell = new ActorSpell(ActorSpellName.ArcaneExplosion, this.ActorType);
                    break;
                case "Bash":
                    actorSpell = new ActorSpell(ActorSpellName.Bash, this.ActorType);
                    break;
                case "ChainLightning":
                    actorSpell = new ActorSpell(ActorSpellName.ChainLightning, this.ActorType);
                    break;
                case "GodBless":
                    actorSpell = new ActorSpell(ActorSpellName.GodBless, this.ActorType);
                    break;
                case "HolyLight":
                    actorSpell = new ActorSpell(ActorSpellName.HolyLight, this.ActorType);
                    break;
                default:
                    actorSpell = new ActorSpell(ActorSpellName.None, this.ActorType);
                    break;
            }
            if (!dictionary.ContainsKey(actorSpell.ActorSpellType))
            {
                dictionary.Add(actorSpell.ActorSpellType, new Dictionary<ActorSpellName, ActorSpell>());
            }
            dictionary[actorSpell.ActorSpellType].Add(actorSpell.ActorSpellName, actorSpell);
        }
        return dictionary;
    }

    public bool HasSpell(ActorSpellName spellName)
    {
        return this.SpellDictionary.Any(kv => kv.Value.ContainsKey(spellName));
    }

    public ActorSpell GetSpell(ActorSpellName spellName)
    {
        return (from kv in this.SpellDictionary where kv.Value.ContainsKey(spellName) select kv.Value[spellName]).FirstOrDefault();
    }

    public Dictionary<ActorSpellName, ActorSpell> GetSpellsByType ( ActorSpellType spellType )
    {
        return this.SpellDictionary.ContainsKey(spellType) ? this.SpellDictionary[spellType] : null;
    }

    #endregion
}