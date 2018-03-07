#region

using System.Collections.Generic;

#endregion

public static class ActorsConfig
{
    #region Public Methods and Operators

    public static ActorArmor GetActorArmor(RaceType raceType, ActorType actorType)
    {
        switch (raceType)
        {
            case RaceType.Terran:
                switch (actorType)
                {
                    case ActorType.Infantry:
                        return TerranActorInfantryConfig.ActorArmor;
                    case ActorType.Supporter:
                        return TerranActorSupporterConfig.ActorArmor;
                    case ActorType.Sniper:
                        return TerranActorSniperConfig.ActorArmor;
                    case ActorType.Marksman:
                        return TerranActorMarksmanConfig.ActorArmor;
                    case ActorType.HeavyGunner:
                        return TerranActorHeavyGunnerConfig.ActorArmor;
                    case ActorType.MortarTeam:
                        return TerranActorMortarTeamConfig.ActorArmor;
                    case ActorType.Warlock:
                        return TerranActorWarlockConfig.ActorArmor;
                    case ActorType.GryphonRider:
                        return TerranActorGryphonRiderConfig.ActorArmor;
                    case ActorType.SeniorGryphonRider:
                        return TerranActorSeniorGryphonRiderConfig.ActorArmor;
                    case ActorType.Crusader:
                        return TerranActorCrusaderConfig.ActorArmor;
                    case ActorType.TemplarWarrior:
                        return TerranActorTemplarWarriorConfig.ActorArmor;
                    case ActorType.Pastor:
                        return TerranActorPastorConfig.ActorArmor;
                    case ActorType.Sage:
                        return TerranActorSageConfig.ActorArmor;
                    case ActorType.Knight:
                        return TerranActorKnightConfig.ActorArmor;
                    case ActorType.Paladin:
                        return TerranActorPaladinConfig.ActorArmor;
                }
                break;
            case RaceType.Orc:
                switch (actorType)
                {
                    case ActorType.Grunt:
                        return OrcActorGruntConfig.ActorArmor;
                    case ActorType.OldGrunt:
                        return OrcActorOldGruntConfig.ActorArmor;
                    case ActorType.TrollBerserker:
                        return OrcActorTrollBerserkerConfig.ActorArmor;
                    case ActorType.TrollHunter:
                        return OrcActorTrollHunterConfig.ActorArmor;
                    case ActorType.BatRider:
                        return OrcActorBatRiderConfig.ActorArmor;
                    case ActorType.SeniorBatRider:
                        return OrcActorSeniorBatRiderConfig.ActorArmor;
                    case ActorType.Shaman:
                        return OrcActorShamanConfig.ActorArmor;
                    case ActorType.WitchDoctor:
                        return OrcActorWitchDoctorConfig.ActorArmor;
                    case ActorType.Raider:
                        return OrcActorRaiderConfig.ActorArmor;
                    case ActorType.Kodo:
                        return OrcActorKodoConfig.ActorArmor;
                    case ActorType.Wyvern:
                        return OrcActorWyvernConfig.ActorArmor;
                    case ActorType.WindRider:
                        return OrcActorWindRiderConfig.ActorArmor;
                    case ActorType.Catapult:
                        return OrcActorCatapultConfig.ActorArmor;
                    case ActorType.SpiritWalker:
                        return OrcActorSpiritWalkerConfig.ActorArmor;
                    case ActorType.Tauren:
                        return OrcActorTaurenConfig.ActorArmor;
                }
                break;
        }
        return null;
    }

    public static ActorAttack GetActorAttack ( RaceType raceType, ActorType actorType )
    {
        switch (raceType)
        {
            case RaceType.Terran:
                switch (actorType)
                {
                    case ActorType.Infantry:
                        return TerranActorInfantryConfig.ActorAttack;
                    case ActorType.Supporter:
                        return TerranActorSupporterConfig.ActorAttack;
                    case ActorType.Sniper:
                        return TerranActorSniperConfig.ActorAttack;
                    case ActorType.Marksman:
                        return TerranActorMarksmanConfig.ActorAttack;
                    case ActorType.HeavyGunner:
                        return TerranActorHeavyGunnerConfig.ActorAttack;
                    case ActorType.MortarTeam:
                        return TerranActorMortarTeamConfig.ActorAttack;
                    case ActorType.Warlock:
                        return TerranActorWarlockConfig.ActorAttack;
                    case ActorType.GryphonRider:
                        return TerranActorGryphonRiderConfig.ActorAttack;
                    case ActorType.SeniorGryphonRider:
                        return TerranActorSeniorGryphonRiderConfig.ActorAttack;
                    case ActorType.Crusader:
                        return TerranActorCrusaderConfig.ActorAttack;
                    case ActorType.TemplarWarrior:
                        return TerranActorTemplarWarriorConfig.ActorAttack;
                    case ActorType.Pastor:
                        return TerranActorPastorConfig.ActorAttack;
                    case ActorType.Sage:
                        return TerranActorSageConfig.ActorAttack;
                    case ActorType.Knight:
                        return TerranActorKnightConfig.ActorAttack;
                    case ActorType.Paladin:
                        return TerranActorPaladinConfig.ActorAttack;
                }
                break;
            case RaceType.Orc:
                switch (actorType)
                {
                    case ActorType.Grunt:
                        return OrcActorGruntConfig.ActorAttack;
                    case ActorType.OldGrunt:
                        return OrcActorOldGruntConfig.ActorAttack;
                    case ActorType.TrollBerserker:
                        return OrcActorTrollBerserkerConfig.ActorAttack;
                    case ActorType.TrollHunter:
                        return OrcActorTrollHunterConfig.ActorAttack;
                    case ActorType.BatRider:
                        return OrcActorBatRiderConfig.ActorAttack;
                    case ActorType.SeniorBatRider:
                        return OrcActorSeniorBatRiderConfig.ActorAttack;
                    case ActorType.Shaman:
                        return OrcActorShamanConfig.ActorAttack;
                    case ActorType.WitchDoctor:
                        return OrcActorWitchDoctorConfig.ActorAttack;
                    case ActorType.Raider:
                        return OrcActorRaiderConfig.ActorAttack;
                    case ActorType.Kodo:
                        return OrcActorKodoConfig.ActorAttack;
                    case ActorType.Wyvern:
                        return OrcActorWyvernConfig.ActorAttack;
                    case ActorType.WindRider:
                        return OrcActorWindRiderConfig.ActorAttack;
                    case ActorType.Catapult:
                        return OrcActorCatapultConfig.ActorAttack;
                    case ActorType.SpiritWalker:
                        return OrcActorSpiritWalkerConfig.ActorAttack;
                    case ActorType.Tauren:
                        return OrcActorTaurenConfig.ActorAttack;
                }
                break;
        }
        return null;
    }

    public static bool GetAttackAirForce ( RaceType raceType, ActorType actorType )
    {
        switch (raceType)
        {
            case RaceType.Terran:
                switch (actorType)
                {
                    case ActorType.Infantry:
                        return TerranActorInfantryConfig.AttackAirForce;
                    case ActorType.Supporter:
                        return TerranActorSupporterConfig.AttackAirForce;
                    case ActorType.Sniper:
                        return TerranActorSniperConfig.AttackAirForce;
                    case ActorType.Marksman:
                        return TerranActorMarksmanConfig.AttackAirForce;
                    case ActorType.HeavyGunner:
                        return TerranActorHeavyGunnerConfig.AttackAirForce;
                    case ActorType.MortarTeam:
                        return TerranActorMortarTeamConfig.AttackAirForce;
                    case ActorType.Warlock:
                        return TerranActorWarlockConfig.AttackAirForce;
                    case ActorType.GryphonRider:
                        return TerranActorGryphonRiderConfig.AttackAirForce;
                    case ActorType.SeniorGryphonRider:
                        return TerranActorSeniorGryphonRiderConfig.AttackAirForce;
                    case ActorType.Crusader:
                        return TerranActorCrusaderConfig.AttackAirForce;
                    case ActorType.TemplarWarrior:
                        return TerranActorTemplarWarriorConfig.AttackAirForce;
                    case ActorType.Pastor:
                        return TerranActorPastorConfig.AttackAirForce;
                    case ActorType.Sage:
                        return TerranActorSageConfig.AttackAirForce;
                    case ActorType.Knight:
                        return TerranActorKnightConfig.AttackAirForce;
                    case ActorType.Paladin:
                        return TerranActorPaladinConfig.AttackAirForce;
                }
                break;
            case RaceType.Orc:
                switch (actorType)
                {
                    case ActorType.Grunt:
                        return OrcActorGruntConfig.AttackAirForce;
                    case ActorType.OldGrunt:
                        return OrcActorOldGruntConfig.AttackAirForce;
                    case ActorType.TrollBerserker:
                        return OrcActorTrollBerserkerConfig.AttackAirForce;
                    case ActorType.TrollHunter:
                        return OrcActorTrollHunterConfig.AttackAirForce;
                    case ActorType.BatRider:
                        return OrcActorBatRiderConfig.AttackAirForce;
                    case ActorType.SeniorBatRider:
                        return OrcActorSeniorBatRiderConfig.AttackAirForce;
                    case ActorType.Shaman:
                        return OrcActorShamanConfig.AttackAirForce;
                    case ActorType.WitchDoctor:
                        return OrcActorWitchDoctorConfig.AttackAirForce;
                    case ActorType.Raider:
                        return OrcActorRaiderConfig.AttackAirForce;
                    case ActorType.Kodo:
                        return OrcActorKodoConfig.AttackAirForce;
                    case ActorType.Wyvern:
                        return OrcActorWyvernConfig.AttackAirForce;
                    case ActorType.WindRider:
                        return OrcActorWindRiderConfig.AttackAirForce;
                    case ActorType.Catapult:
                        return OrcActorCatapultConfig.AttackAirForce;
                    case ActorType.SpiritWalker:
                        return OrcActorSpiritWalkerConfig.AttackAirForce;
                    case ActorType.Tauren:
                        return OrcActorTaurenConfig.AttackAirForce;
                }
                break;
        }
        return false;
    }

    public static bool GetIsAirForce ( RaceType raceType, ActorType actorType )
    {
        switch (raceType)
        {
            case RaceType.Terran:
                switch (actorType)
                {
                    case ActorType.Infantry:
                        return TerranActorInfantryConfig.IsAirForce;
                    case ActorType.Supporter:
                        return TerranActorSupporterConfig.IsAirForce;
                    case ActorType.Sniper:
                        return TerranActorSniperConfig.IsAirForce;
                    case ActorType.Marksman:
                        return TerranActorMarksmanConfig.IsAirForce;
                    case ActorType.HeavyGunner:
                        return TerranActorHeavyGunnerConfig.IsAirForce;
                    case ActorType.MortarTeam:
                        return TerranActorMortarTeamConfig.IsAirForce;
                    case ActorType.Warlock:
                        return TerranActorWarlockConfig.IsAirForce;
                    case ActorType.GryphonRider:
                        return TerranActorGryphonRiderConfig.IsAirForce;
                    case ActorType.SeniorGryphonRider:
                        return TerranActorSeniorGryphonRiderConfig.IsAirForce;
                    case ActorType.Crusader:
                        return TerranActorCrusaderConfig.IsAirForce;
                    case ActorType.TemplarWarrior:
                        return TerranActorTemplarWarriorConfig.IsAirForce;
                    case ActorType.Pastor:
                        return TerranActorPastorConfig.IsAirForce;
                    case ActorType.Sage:
                        return TerranActorSageConfig.IsAirForce;
                    case ActorType.Knight:
                        return TerranActorKnightConfig.IsAirForce;
                    case ActorType.Paladin:
                        return TerranActorPaladinConfig.IsAirForce;
                }
                break;
            case RaceType.Orc:
                switch (actorType)
                {
                    case ActorType.Grunt:
                        return OrcActorGruntConfig.IsAirForce;
                    case ActorType.OldGrunt:
                        return OrcActorOldGruntConfig.IsAirForce;
                    case ActorType.TrollBerserker:
                        return OrcActorTrollBerserkerConfig.IsAirForce;
                    case ActorType.TrollHunter:
                        return OrcActorTrollHunterConfig.IsAirForce;
                    case ActorType.BatRider:
                        return OrcActorBatRiderConfig.IsAirForce;
                    case ActorType.SeniorBatRider:
                        return OrcActorSeniorBatRiderConfig.IsAirForce;
                    case ActorType.Shaman:
                        return OrcActorShamanConfig.IsAirForce;
                    case ActorType.WitchDoctor:
                        return OrcActorWitchDoctorConfig.IsAirForce;
                    case ActorType.Raider:
                        return OrcActorRaiderConfig.IsAirForce;
                    case ActorType.Kodo:
                        return OrcActorKodoConfig.IsAirForce;
                    case ActorType.Wyvern:
                        return OrcActorWyvernConfig.IsAirForce;
                    case ActorType.WindRider:
                        return OrcActorWindRiderConfig.IsAirForce;
                    case ActorType.Catapult:
                        return OrcActorCatapultConfig.IsAirForce;
                    case ActorType.SpiritWalker:
                        return OrcActorSpiritWalkerConfig.IsAirForce;
                    case ActorType.Tauren:
                        return OrcActorTaurenConfig.IsAirForce;
                }
                break;
        }
        return false;
    }

    public static int GetHp ( RaceType raceType, ActorType actorType )
    {
        switch (raceType)
        {
            case RaceType.Terran:
                switch (actorType)
                {
                    case ActorType.Infantry:
                        return TerranActorInfantryConfig.Hp;
                    case ActorType.Supporter:
                        return TerranActorSupporterConfig.Hp;
                    case ActorType.Sniper:
                        return TerranActorSniperConfig.Hp;
                    case ActorType.Marksman:
                        return TerranActorMarksmanConfig.Hp;
                    case ActorType.HeavyGunner:
                        return TerranActorHeavyGunnerConfig.Hp;
                    case ActorType.MortarTeam:
                        return TerranActorMortarTeamConfig.Hp;
                    case ActorType.Warlock:
                        return TerranActorWarlockConfig.Hp;
                    case ActorType.GryphonRider:
                        return TerranActorGryphonRiderConfig.Hp;
                    case ActorType.SeniorGryphonRider:
                        return TerranActorSeniorGryphonRiderConfig.Hp;
                    case ActorType.Crusader:
                        return TerranActorCrusaderConfig.Hp;
                    case ActorType.TemplarWarrior:
                        return TerranActorTemplarWarriorConfig.Hp;
                    case ActorType.Pastor:
                        return TerranActorPastorConfig.Hp;
                    case ActorType.Sage:
                        return TerranActorSageConfig.Hp;
                    case ActorType.Knight:
                        return TerranActorKnightConfig.Hp;
                    case ActorType.Paladin:
                        return TerranActorPaladinConfig.Hp;
                }
                break;
            case RaceType.Orc:
                switch (actorType)
                {
                    case ActorType.Grunt:
                        return OrcActorGruntConfig.Hp;
                    case ActorType.OldGrunt:
                        return OrcActorOldGruntConfig.Hp;
                    case ActorType.TrollBerserker:
                        return OrcActorTrollBerserkerConfig.Hp;
                    case ActorType.TrollHunter:
                        return OrcActorTrollHunterConfig.Hp;
                    case ActorType.BatRider:
                        return OrcActorBatRiderConfig.Hp;
                    case ActorType.SeniorBatRider:
                        return OrcActorSeniorBatRiderConfig.Hp;
                    case ActorType.Shaman:
                        return OrcActorShamanConfig.Hp;
                    case ActorType.WitchDoctor:
                        return OrcActorWitchDoctorConfig.Hp;
                    case ActorType.Raider:
                        return OrcActorRaiderConfig.Hp;
                    case ActorType.Kodo:
                        return OrcActorKodoConfig.Hp;
                    case ActorType.Wyvern:
                        return OrcActorWyvernConfig.Hp;
                    case ActorType.WindRider:
                        return OrcActorWindRiderConfig.Hp;
                    case ActorType.Catapult:
                        return OrcActorCatapultConfig.Hp;
                    case ActorType.SpiritWalker:
                        return OrcActorSpiritWalkerConfig.Hp;
                    case ActorType.Tauren:
                        return OrcActorTaurenConfig.Hp;
                }
                break;
        }
        return 0;
    }

    public static ActorLevel GetActorLevel(RaceType raceType, ActorType actorType)
    {
        switch (raceType)
        {
            case RaceType.Terran:
                switch (actorType)
                {
                    case ActorType.Infantry:
                        return TerranActorInfantryConfig.ActorLevel;
                    case ActorType.Supporter:
                        return TerranActorSupporterConfig.ActorLevel;
                    case ActorType.Sniper:
                        return TerranActorSniperConfig.ActorLevel;
                    case ActorType.Marksman:
                        return TerranActorMarksmanConfig.ActorLevel;
                    case ActorType.HeavyGunner:
                        return TerranActorHeavyGunnerConfig.ActorLevel;
                    case ActorType.MortarTeam:
                        return TerranActorMortarTeamConfig.ActorLevel;
                    case ActorType.Warlock:
                        return TerranActorWarlockConfig.ActorLevel;
                    case ActorType.GryphonRider:
                        return TerranActorGryphonRiderConfig.ActorLevel;
                    case ActorType.SeniorGryphonRider:
                        return TerranActorSeniorGryphonRiderConfig.ActorLevel;
                    case ActorType.Crusader:
                        return TerranActorCrusaderConfig.ActorLevel;
                    case ActorType.TemplarWarrior:
                        return TerranActorTemplarWarriorConfig.ActorLevel;
                    case ActorType.Pastor:
                        return TerranActorPastorConfig.ActorLevel;
                    case ActorType.Sage:
                        return TerranActorSageConfig.ActorLevel;
                    case ActorType.Knight:
                        return TerranActorKnightConfig.ActorLevel;
                    case ActorType.Paladin:
                        return TerranActorPaladinConfig.ActorLevel;
                }
                break;
            case RaceType.Orc:
                switch (actorType)
                {
                    case ActorType.Grunt:
                        return OrcActorGruntConfig.ActorLevel;
                    case ActorType.OldGrunt:
                        return OrcActorOldGruntConfig.ActorLevel;
                    case ActorType.TrollBerserker:
                        return OrcActorTrollBerserkerConfig.ActorLevel;
                    case ActorType.TrollHunter:
                        return OrcActorTrollHunterConfig.ActorLevel;
                    case ActorType.BatRider:
                        return OrcActorBatRiderConfig.ActorLevel;
                    case ActorType.SeniorBatRider:
                        return OrcActorSeniorBatRiderConfig.ActorLevel;
                    case ActorType.Shaman:
                        return OrcActorShamanConfig.ActorLevel;
                    case ActorType.WitchDoctor:
                        return OrcActorWitchDoctorConfig.ActorLevel;
                    case ActorType.Raider:
                        return OrcActorRaiderConfig.ActorLevel;
                    case ActorType.Kodo:
                        return OrcActorKodoConfig.ActorLevel;
                    case ActorType.Wyvern:
                        return OrcActorWyvernConfig.ActorLevel;
                    case ActorType.WindRider:
                        return OrcActorWindRiderConfig.ActorLevel;
                    case ActorType.Catapult:
                        return OrcActorCatapultConfig.ActorLevel;
                    case ActorType.SpiritWalker:
                        return OrcActorSpiritWalkerConfig.ActorLevel;
                    case ActorType.Tauren:
                        return OrcActorTaurenConfig.ActorLevel;
                }
                break;
        }
        return 0;
    }

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> GetSpellDictionary ( RaceType raceType, ActorType actorType )
    {
        if (raceType == RaceType.Terran)
        {
            switch (actorType)
            {
                case ActorType.Infantry:
                    return TerranActorInfantryConfig.SpellDictionary;
                case ActorType.Supporter:
                    return TerranActorSupporterConfig.SpellDictionary;
                case ActorType.Sniper:
                    return TerranActorSniperConfig.SpellDictionary;
                case ActorType.Marksman:
                    return TerranActorMarksmanConfig.SpellDictionary;
                case ActorType.HeavyGunner:
                    return TerranActorHeavyGunnerConfig.SpellDictionary;
                case ActorType.MortarTeam:
                    return TerranActorMortarTeamConfig.SpellDictionary;
                case ActorType.Warlock:
                    return TerranActorWarlockConfig.SpellDictionary;
                case ActorType.GryphonRider:
                    return TerranActorGryphonRiderConfig.SpellDictionary;
                case ActorType.SeniorGryphonRider:
                    return TerranActorSeniorGryphonRiderConfig.SpellDictionary;
                case ActorType.Crusader:
                    return TerranActorCrusaderConfig.SpellDictionary;
                case ActorType.TemplarWarrior:
                    return TerranActorTemplarWarriorConfig.SpellDictionary;
                case ActorType.Pastor:
                    return TerranActorPastorConfig.SpellDictionary;
                case ActorType.Sage:
                    return TerranActorSageConfig.SpellDictionary;
                case ActorType.Knight:
                    return TerranActorKnightConfig.SpellDictionary;
                case ActorType.Paladin:
                    return TerranActorPaladinConfig.SpellDictionary;
            }
        }
        else if (raceType == RaceType.Orc)
        {
            switch (actorType)
            {
                case ActorType.Grunt:
                    return OrcActorGruntConfig.SpellDictionary;
                case ActorType.OldGrunt:
                    return OrcActorOldGruntConfig.SpellDictionary;
                case ActorType.TrollBerserker:
                    return OrcActorTrollBerserkerConfig.SpellDictionary;
                case ActorType.TrollHunter:
                    return OrcActorTrollHunterConfig.SpellDictionary;
                case ActorType.BatRider:
                    return OrcActorBatRiderConfig.SpellDictionary;
                case ActorType.SeniorBatRider:
                    return OrcActorSeniorBatRiderConfig.SpellDictionary;
                case ActorType.Shaman:
                    return OrcActorShamanConfig.SpellDictionary;
                case ActorType.WitchDoctor:
                    return OrcActorWitchDoctorConfig.SpellDictionary;
                case ActorType.Raider:
                    return OrcActorRaiderConfig.SpellDictionary;
                case ActorType.Kodo:
                    return OrcActorKodoConfig.SpellDictionary;
                case ActorType.Wyvern:
                    return OrcActorWyvernConfig.SpellDictionary;
                case ActorType.WindRider:
                    return OrcActorWindRiderConfig.SpellDictionary;
                case ActorType.Catapult:
                    return OrcActorCatapultConfig.SpellDictionary;
                case ActorType.SpiritWalker:
                    return OrcActorSpiritWalkerConfig.SpellDictionary;
                case ActorType.Tauren:
                    return OrcActorTaurenConfig.SpellDictionary;
            }
        }
        return null;
    }

    public static List<ActorType> GetAllActorTypesOfRaceType(RaceType raceType)
    {
        List<ActorType> result = new List<ActorType>();
        switch (raceType)
        {
            case RaceType.Terran:
                {
                    result.Add(ActorType.Infantry);
                    result.Add(ActorType.Supporter);
                    result.Add(ActorType.Sniper);
                    result.Add(ActorType.Marksman);
                    result.Add(ActorType.HeavyGunner);
                    result.Add(ActorType.MortarTeam);
                    result.Add(ActorType.Warlock);
                    result.Add(ActorType.GryphonRider);
                    result.Add(ActorType.SeniorGryphonRider);
                    result.Add(ActorType.Crusader);
                    result.Add(ActorType.TemplarWarrior);
                    result.Add(ActorType.Pastor);
                    result.Add(ActorType.Sage);
                    result.Add(ActorType.Knight);
                    result.Add(ActorType.Paladin);
                    break;
                }
            case RaceType.Orc:
                {
                    result.Add(ActorType.BatRider);
                    result.Add(ActorType.Catapult);
                    result.Add(ActorType.Grunt);
                    result.Add(ActorType.Kodo); 
                    result.Add(ActorType.OldGrunt);
                    result.Add(ActorType.Raider);
                    result.Add(ActorType.SeniorBatRider);
                    result.Add(ActorType.Shaman);
                    result.Add(ActorType.SpiritWalker);
                    result.Add(ActorType.Tauren);
                    result.Add(ActorType.TrollBerserker);
                    result.Add(ActorType.TrollHunter);
                    result.Add(ActorType.WindRider);
                    result.Add(ActorType.WitchDoctor);
                    result.Add(ActorType.Wyvern);
                    break;
                }
        }
        return result;
    }

    public static RaceType GetActorRaceType ( ActorType actorType )
    {
        string temp = actorType + "";
        if (temp.Contains("Terran")) return RaceType.Terran;
        if (temp.Contains("Orc")) return RaceType.Orc;
        return 0;
    }

    #endregion
}

/// <summary>
/// 人族
/// </summary>
public static class TerranActorInfantryConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.HeavyArmor, 4);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Normal, 0, 18);

    public static ActorType ActorType = ActorType.Infantry;

    public static bool AttackAirForce = false;

    public static int Hp = 250;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .Parry,
                                new ActorSpell
                                (
                                ActorSpellName
                                .Parry,
                                ActorType
                                .Infantry)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorSupporterConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.HeavyArmor, 7);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Normal, 0, 38);

    public static ActorType ActorType = ActorType.Supporter;

    public static bool AttackAirForce = false;

    public static int Hp = 575;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .Dodge,
                                new ActorSpell
                                (
                                ActorSpellName
                                .Dodge,
                                ActorType
                                .Supporter)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorSniperConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 0);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Pierce, 150, 22);

    public static ActorType ActorType = ActorType.Sniper;

    public static bool AttackAirForce = true;

    public static int Hp = 270;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .CirticalStrike,
                                new ActorSpell
                                (
                                ActorSpellName
                                .CirticalStrike,
                                ActorType
                                .Sniper)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorMarksmanConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 1);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Pierce, 160, 61);

    public static ActorType ActorType = ActorType.Marksman;

    public static bool AttackAirForce = true;

    public static int Hp = 450;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .HeadShot,
                                new ActorSpell
                                (
                                ActorSpellName
                                .HeadShot,
                                ActorType
                                .Marksman)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorHeavyGunnerConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 3);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Siege, 155, 53);

    public static ActorType ActorType = ActorType.HeavyGunner;

    public static bool AttackAirForce = false;

    public static int Hp = 500;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .SplashDamage,
                                new ActorSpell
                                (
                                ActorSpellName
                                .SplashDamage,
                                ActorType
                                .HeavyGunner)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorMortarTeamConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 0);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Pierce, 200, 21);

    public static ActorType ActorType = ActorType.MortarTeam;

    public static bool AttackAirForce = false;

    public static int Hp = 260;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.ActiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .MortarAttack,
                                new ActorSpell
                                (
                                ActorSpellName
                                .MortarAttack,
                                ActorType
                                .MortarTeam)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorWarlockConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 1);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Confuse, 120, 17);

    public static ActorType ActorType = ActorType.Warlock;

    public static bool AttackAirForce = true;

    public static int Hp = 320;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.ActiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .ArcaneExplosion,
                                new ActorSpell
                                (
                                ActorSpellName
                                .ArcaneExplosion,
                                ActorType
                                .Warlock)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorGryphonRiderConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 2);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Magic, 145, 23);

    public static ActorType ActorType = ActorType.GryphonRider;

    public static bool AttackAirForce = true;

    public static int Hp = 500;

    public static bool IsAirForce = true;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .Bleed,
                                new ActorSpell
                                (
                                ActorSpellName
                                .Bleed,
                                ActorType
                                .GryphonRider)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorSeniorGryphonRiderConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 5);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Magic, 150, 30);

    public static ActorType ActorType = ActorType.SeniorGryphonRider;

    public static bool AttackAirForce = true;

    public static int Hp = 650;

    public static bool IsAirForce = true;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .Bleed,
                                new ActorSpell
                                (
                                ActorSpellName
                                .Bleed,
                                ActorType
                                .SeniorGryphonRider)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorCrusaderConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.HeavyArmor, 6);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Normal, 0, 42);

    public static ActorType ActorType = ActorType.Crusader;

    public static bool AttackAirForce = false;

    public static int Hp = 600;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .Bash,
                                new ActorSpell
                                (
                                ActorSpellName
                                .Bash,
                                ActorType
                                .Crusader)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorTemplarWarriorConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.HeavyArmor, 9);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.HeroAttack, 0, 67);

    public static ActorType ActorType = ActorType.TemplarWarrior;

    public static bool AttackAirForce = false;

    public static int Hp = 850;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .Bash,
                                new ActorSpell
                                (
                                ActorSpellName
                                .Bash,
                                ActorType
                                .TemplarWarrior)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorPastorConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 1);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Magic, 150, 20);

    public static ActorType ActorType = ActorType.Pastor;

    public static bool AttackAirForce = true;

    public static int Hp = 550;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.ActiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .HolyLight,
                                new ActorSpell
                                (
                                ActorSpellName
                                .HolyLight,
                                ActorType
                                .Pastor)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorSageConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 3);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Magic, 160, 45);

    public static ActorType ActorType = ActorType.Sage;

    public static bool AttackAirForce = true;

    public static int Hp = 600;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .ChainLightning,
                                new ActorSpell
                                (
                                ActorSpellName
                                .ChainLightning,
                                ActorType
                                .Sage)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorKnightConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.HeavyArmor, 7);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Normal, 0, 50);

    public static ActorType ActorType = ActorType.Knight;

    public static bool AttackAirForce = false;

    public static int Hp = 600;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.ActiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .GodBless,
                                new ActorSpell
                                (
                                ActorSpellName
                                .GodBless,
                                ActorType
                                .Knight)
                            }
                        }
                }
            };

    #endregion
}

public static class TerranActorPaladinConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.HeavyArmor, 10);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.HeroAttack, 0, 70);

    public static ActorType ActorType = ActorType.Paladin;

    public static bool AttackAirForce = false;

    public static int Hp = 800;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.ActiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .GodBless,
                                new ActorSpell
                                (
                                ActorSpellName
                                .GodBless,
                                ActorType
                                .Paladin)
                            }
                        }
                }
            };

    #endregion
}

/// <summary>
/// 兽族
/// </summary>

public static class OrcActorGruntConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.HeavyArmor, 4);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Normal, 0, 18);

    public static ActorType ActorType = ActorType.Grunt;

    public static bool AttackAirForce = false;

    public static int Hp = 325;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.ActiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .None,
                                new ActorSpell
                                (
                                ActorSpellName
                                .None,
                                ActorType
                                .Grunt)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorOldGruntConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.HeavyArmor, 6);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Normal, 0, 25);

    public static ActorType ActorType = ActorType.OldGrunt;

    public static bool AttackAirForce = false;

    public static int Hp = 550;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .CirticalStrike,
                                new ActorSpell
                                (
                                ActorSpellName
                                .CirticalStrike,
                                ActorType
                                .OldGrunt)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorTrollBerserkerConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 3);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Normal, 130, 30);

    public static ActorType ActorType = ActorType.TrollBerserker;

    public static bool AttackAirForce = true;

    public static int Hp = 450;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .Rage,
                                new ActorSpell
                                (
                                ActorSpellName
                                .Rage,
                                ActorType
                                .TrollBerserker)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorTrollHunterConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 4);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Normal, 135, 38);

    public static ActorType ActorType = ActorType.TrollHunter;

    public static bool AttackAirForce = true;

    public static int Hp = 650;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .Rage,
                                new ActorSpell
                                (
                                ActorSpellName
                                .Rage,
                                ActorType
                                .TrollHunter)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorBatRiderConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 2);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Pierce, 140, 28);

    public static ActorType ActorType = ActorType.BatRider;

    public static bool AttackAirForce = true;

    public static int Hp = 420;

    public static bool IsAirForce = true;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .FireBomb,
                                new ActorSpell
                                (
                                ActorSpellName
                                .FireBomb,
                                ActorType
                                .BatRider)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorSeniorBatRiderConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 4);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Pierce, 160, 35);

    public static ActorType ActorType = ActorType.SeniorBatRider;

    public static bool AttackAirForce = true;

    public static int Hp = 450;

    public static bool IsAirForce = true;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .FireBomb,
                                new ActorSpell
                                (
                                ActorSpellName
                                .FireBomb,
                                ActorType
                                .SeniorBatRider)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorShamanConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 1);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Magic, 135, 26);

    public static ActorType ActorType = ActorType.Shaman;

    public static bool AttackAirForce = false;

    public static int Hp = 340;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.ActiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .ShamanBless,
                                new ActorSpell
                                (
                                ActorSpellName
                                .ShamanBless,
                                ActorType
                                .Shaman)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorWitchDoctorConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 4);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Magic, 140, 35);

    public static ActorType ActorType = ActorType.WitchDoctor;

    public static bool AttackAirForce = true;

    public static int Hp = 600;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.ActiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .ChainHeal,
                                new ActorSpell
                                (
                                ActorSpellName
                                .ChainHeal,
                                ActorType
                                .WitchDoctor)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorRaiderConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 6);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Normal, 0, 24);

    public static ActorType ActorType = ActorType.Raider;

    public static bool AttackAirForce = false;

    public static int Hp = 1100;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.ActiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .Ensnare,
                                new ActorSpell
                                (
                                ActorSpellName
                                .Ensnare,
                                ActorType
                                .Raider)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorKodoConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 7);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Pierce, 120, 33);

    public static ActorType ActorType = ActorType.Kodo;

    public static bool AttackAirForce = true;

    public static int Hp = 1200;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.BuffSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .SongOfOffense,
                                new ActorSpell
                                (
                                ActorSpellName
                                .SongOfOffense,
                                ActorType
                                .Kodo)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorWyvernConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 2);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Pierce, 140, 23);

    public static ActorType ActorType = ActorType.Wyvern;

    public static bool AttackAirForce = true;

    public static int Hp = 400;

    public static bool IsAirForce = true;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .PoisonAttack,
                                new ActorSpell
                                (
                                ActorSpellName
                                .PoisonAttack,
                                ActorType
                                .Wyvern)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorWindRiderConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.LightArmor, 5);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Pierce, 140, 30);

    public static ActorType ActorType = ActorType.WindRider;

    public static bool AttackAirForce = true;

    public static int Hp = 550;

    public static bool IsAirForce = true;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .PoisonAttack,
                                new ActorSpell
                                (
                                ActorSpellName
                                .PoisonAttack,
                                ActorType
                                .WindRider)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorCatapultConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.HeavyArmor, 5);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Siege, 200, 48);

    public static ActorType ActorType = ActorType.Catapult;

    public static bool AttackAirForce = false;

    public static int Hp = 475;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .BurningOil,
                                new ActorSpell
                                (
                                ActorSpellName
                                .BurningOil,
                                ActorType
                                .Catapult)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorSpiritWalkerConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.HeavyArmor, 5);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.Normal, 0, 50);

    public static ActorType ActorType = ActorType.SpiritWalker;

    public static bool AttackAirForce = false;

    public static int Hp = 900;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Normal;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.ActiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .SpiritLink,
                                new ActorSpell
                                (
                                ActorSpellName
                                .SpiritLink,
                                ActorType
                                .SpiritWalker)
                            }
                        }
                }
            };

    #endregion
}

public static class OrcActorTaurenConfig
{
    #region Static Fields

    public static ActorArmor ActorArmor = new ActorArmor(ActorArmorType.HeavyArmor, 9);

    public static ActorAttack ActorAttack = new ActorAttack(ActorAttackType.HeroAttack, 0, 60);

    public static ActorType ActorType = ActorType.Tauren;

    public static bool AttackAirForce = false;

    public static int Hp = 1000;

    public static bool IsAirForce = false;

    public static ActorLevel ActorLevel = ActorLevel.Senior;

    public static Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>> SpellDictionary =
        new Dictionary<ActorSpellType, Dictionary<ActorSpellName, ActorSpell>>
            {
                {
                    ActorSpellType.PassiveSpell,
                    new Dictionary
                    <ActorSpellName, ActorSpell>
                        {
                            {
                                ActorSpellName
                                .Smash,
                                new ActorSpell
                                (
                                ActorSpellName
                                .Smash,
                                ActorType
                                .Tauren)
                            }
                        }
                }
            };

    #endregion
}