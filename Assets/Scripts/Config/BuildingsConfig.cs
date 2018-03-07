#region

using System.Collections.Generic;

#endregion

public static class BuildingsConfig
{
    #region Public Methods and Operators

    public static List<BuildingType> GetAllBuildingTypesOfRaceType(RaceType raceType)
    {
        List<BuildingType> result = new List<BuildingType>();
        switch (raceType)
        {
            case RaceType.Terran:
                {
                    result.Add(BuildingType.Terran_Barrack);
                    result.Add(BuildingType.Terran_SniperHouse);
                    result.Add(BuildingType.Terran_ArtilleryLab);
                    result.Add(BuildingType.Terran_MysterySchool);
                    result.Add(BuildingType.Terran_Aviary);
                    result.Add(BuildingType.Terran_Fortress);
                    result.Add(BuildingType.Terran_Church);
                    result.Add(BuildingType.Terran_Temple);
                }
                break;
            case RaceType.Orc:
                {
                    result.Add(BuildingType.Orc_WarriorHall);
                    result.Add(BuildingType.Orc_TrollHouse);
                    result.Add(BuildingType.Orc_ThePound);
                    result.Add(BuildingType.Orc_ShamanTent); 
                    result.Add(BuildingType.Orc_AnimalFarm);
                    result.Add(BuildingType.Orc_WyvernCamp);
                    result.Add(BuildingType.Orc_OrcFactory);
                    result.Add(BuildingType.Orc_TheTaurenVine);
                }
                break;
        }
        return result;
    }

    public static string GetBuildingName(RaceType raceType, BuildingType buildingType)
    {
        switch (raceType)
        {
            case RaceType.Terran:
                switch (buildingType)
                {
                    case BuildingType.Terran_Barrack:
                        return TerranBuildingBarrackConfig.BuildingName;
                    case BuildingType.Terran_SniperHouse:
                        return TerranBuildingSniperHouseConfig.BuildingName;
                    case BuildingType.Terran_ArtilleryLab:
                        return TerranBuildingArtilleryLabConfig.BuildingName;
                    case BuildingType.Terran_MysterySchool:
                        return TerranBuildingMysterySchoolConfig.BuildingName;
                    case BuildingType.Terran_Aviary:
                        return TerranBuildingAviaryConfig.BuildingName;
                    case BuildingType.Terran_Fortress:
                        return TerranBuildingFortressConfig.BuildingName;
                    case BuildingType.Terran_Church:
                        return TerranBuildingChurchConfig.BuildingName;
                    case BuildingType.Terran_Temple:
                        return TerranBuildingTempleConfig.BuildingName;
                }
                break;
            case RaceType.Orc:
                switch (buildingType)
                {
                    case BuildingType.Orc_AnimalFarm:
                        return OrcBuildingAnimalFarmConfig.BuildingName;
                    case BuildingType.Orc_OrcFactory:
                        return OrcBuildingOrcFactoryConfig.BuildingName;
                    case BuildingType.Orc_ShamanTent:
                        return OrcBuildingShamanTentConfig.BuildingName;
                    case BuildingType.Orc_ThePound:
                        return OrcBuildingThePoundConfig.BuildingName;
                    case BuildingType.Orc_TheTaurenVine:
                        return OrcBuildingTheTaurenVineConfig.BuildingName;
                    case BuildingType.Orc_TrollHouse:
                        return OrcBuildingTrollHouseConfig.BuildingName;
                    case BuildingType.Orc_WarriorHall:
                        return OrcBuildingWarriorHallConfig.BuildingName;
                    case BuildingType.Orc_WyvernCamp:
                        return OrcBuildingWyvernCampConfig.BuildingName;
                }
                break;
        }
        return string.Empty;
    }

    public static RaceType GetBuildingRaceType(BuildingType buildingType)
    {
        string temp = buildingType + "";
        if (temp.Contains("Terran"))
        {
            return RaceType.Terran;
        }
        if (temp.Contains("Orc"))
        {
            return RaceType.Orc;
        }
        return 0;
    }

    public static int GetCoinCost(RaceType raceType, BuildingType buildingType, BuildingLevel buildingLevel)
    {
        switch (raceType)
        {
            case RaceType.Terran:
                switch (buildingType)
                {
                    case BuildingType.Terran_Barrack:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingBarrackConfig.CoinCostLevel1
                                   : TerranBuildingBarrackConfig.CoinCostLevel2;
                    case BuildingType.Terran_SniperHouse:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingSniperHouseConfig.CoinCostLevel1
                                   : TerranBuildingSniperHouseConfig.CoinCostLevel2;
                    case BuildingType.Terran_ArtilleryLab:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingArtilleryLabConfig.CoinCostLevel1
                                   : TerranBuildingArtilleryLabConfig.CoinCostLevel2;
                    case BuildingType.Terran_MysterySchool:
                        return TerranBuildingMysterySchoolConfig.CoinCostLevel1;
                    case BuildingType.Terran_Aviary:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingAviaryConfig.CoinCostLevel1
                                   : TerranBuildingAviaryConfig.CoinCostLevel2;
                    case BuildingType.Terran_Fortress:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingFortressConfig.CoinCostLevel1
                                   : TerranBuildingFortressConfig.CoinCostLevel2;
                    case BuildingType.Terran_Church:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingChurchConfig.CoinCostLevel1
                                   : TerranBuildingChurchConfig.CoinCostLevel2;
                    case BuildingType.Terran_Temple:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingTempleConfig.CoinCostLevel1
                                   : TerranBuildingTempleConfig.CoinCostLevel2;
                }
                break;
            case RaceType.Orc:
                switch (buildingType)
                {
                    case BuildingType.Orc_AnimalFarm:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingAnimalFarmConfig.CoinCostLevel1
                                   : OrcBuildingAnimalFarmConfig.CoinCostLevel2;
                    case BuildingType.Orc_OrcFactory:
                        return OrcBuildingOrcFactoryConfig.CoinCostLevel1;
                    case BuildingType.Orc_ShamanTent:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingShamanTentConfig.CoinCostLevel1
                                   : OrcBuildingShamanTentConfig.CoinCostLevel2;
                    case BuildingType.Orc_ThePound:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingThePoundConfig.CoinCostLevel1
                                   : OrcBuildingThePoundConfig.CoinCostLevel2;
                    case BuildingType.Orc_TheTaurenVine:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingTheTaurenVineConfig.CoinCostLevel1
                                   : OrcBuildingTheTaurenVineConfig.CoinCostLevel2;
                    case BuildingType.Orc_TrollHouse:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingTrollHouseConfig.CoinCostLevel1
                                   : OrcBuildingTrollHouseConfig.CoinCostLevel2;
                    case BuildingType.Orc_WarriorHall:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingWarriorHallConfig.CoinCostLevel1
                                   : OrcBuildingWarriorHallConfig.CoinCostLevel2;
                    case BuildingType.Orc_WyvernCamp:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingWyvernCampConfig.CoinCostLevel1
                                   : OrcBuildingWyvernCampConfig.CoinCostLevel2;
                }
                break;
        }
        return 0;
    }

    public static int GetHp(RaceType raceType, BuildingType buildingType, BuildingLevel buildingLevel)
    {
        switch (raceType)
        {
            case RaceType.Terran:
                switch (buildingType)
                {
                    case BuildingType.Terran_Barrack:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingBarrackConfig.HpLevel1
                                   : TerranBuildingBarrackConfig.HpLevel2;
                    case BuildingType.Terran_SniperHouse:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingSniperHouseConfig.HpLevel1
                                   : TerranBuildingSniperHouseConfig.HpLevel2;
                    case BuildingType.Terran_ArtilleryLab:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingArtilleryLabConfig.HpLevel1
                                   : TerranBuildingArtilleryLabConfig.HpLevel2;
                    case BuildingType.Terran_MysterySchool:
                        return TerranBuildingMysterySchoolConfig.HpLevel1;
                    case BuildingType.Terran_Aviary:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingAviaryConfig.HpLevel1
                                   : TerranBuildingAviaryConfig.HpLevel2;
                    case BuildingType.Terran_Fortress:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingFortressConfig.HpLevel1
                                   : TerranBuildingFortressConfig.HpLevel2;
                    case BuildingType.Terran_Church:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingChurchConfig.HpLevel1
                                   : TerranBuildingChurchConfig.HpLevel2;
                    case BuildingType.Terran_Temple:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingTempleConfig.HpLevel1
                                   : TerranBuildingTempleConfig.HpLevel2;
                    case BuildingType.Terran_TheMainCity:
                        return 20000;
                }
                break;
            case RaceType.Orc:
                switch (buildingType)
                {
                    case BuildingType.Orc_AnimalFarm:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingAnimalFarmConfig.HpLevel1
                                   : OrcBuildingAnimalFarmConfig.HpLevel2;
                    case BuildingType.Orc_OrcFactory:
                        return OrcBuildingOrcFactoryConfig.HpLevel1;
                    case BuildingType.Orc_ShamanTent:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingShamanTentConfig.HpLevel1
                                   : OrcBuildingShamanTentConfig.HpLevel2;
                    case BuildingType.Orc_ThePound:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingThePoundConfig.HpLevel1
                                   : OrcBuildingThePoundConfig.HpLevel2;
                    case BuildingType.Orc_TheTaurenVine:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingTheTaurenVineConfig.HpLevel1
                                   : OrcBuildingTheTaurenVineConfig.HpLevel2;
                    case BuildingType.Orc_TrollHouse:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingTrollHouseConfig.HpLevel1
                                   : OrcBuildingTrollHouseConfig.HpLevel2;
                    case BuildingType.Orc_WarriorHall:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingWarriorHallConfig.HpLevel1
                                   : OrcBuildingWarriorHallConfig.HpLevel2;
                    case BuildingType.Orc_WyvernCamp:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingWyvernCampConfig.HpLevel1
                                   : OrcBuildingWyvernCampConfig.HpLevel2;
                    case BuildingType.Orc_TheMainCity:
                        return 20000;
                }
                break;
        }
        return 0;
    }

    public static BuildingLevel GetMaxLevel(RaceType raceType, BuildingType buildingType)
    {
        switch (raceType)
        {
            case RaceType.Terran:
                switch (buildingType)
                {
                    case BuildingType.Terran_Barrack:
                        return TerranBuildingBarrackConfig.MaxLevel;
                    case BuildingType.Terran_SniperHouse:
                        return TerranBuildingSniperHouseConfig.MaxLevel;
                    case BuildingType.Terran_ArtilleryLab:
                        return TerranBuildingArtilleryLabConfig.MaxLevel;
                    case BuildingType.Terran_MysterySchool:
                        return TerranBuildingMysterySchoolConfig.MaxLevel;
                    case BuildingType.Terran_Aviary:
                        return TerranBuildingAviaryConfig.MaxLevel;
                    case BuildingType.Terran_Fortress:
                        return TerranBuildingFortressConfig.MaxLevel;
                    case BuildingType.Terran_Church:
                        return TerranBuildingChurchConfig.MaxLevel;
                    case BuildingType.Terran_Temple:
                        return TerranBuildingTempleConfig.MaxLevel;
                }
                break;
            case RaceType.Orc:
                switch (buildingType)
                {
                    case BuildingType.Orc_AnimalFarm:
                        return OrcBuildingAnimalFarmConfig.MaxLevel;
                    case BuildingType.Orc_OrcFactory:
                        return OrcBuildingOrcFactoryConfig.MaxLevel;
                    case BuildingType.Orc_ShamanTent:
                        return OrcBuildingShamanTentConfig.MaxLevel;
                    case BuildingType.Orc_ThePound:
                        return OrcBuildingThePoundConfig.MaxLevel;
                    case BuildingType.Orc_TheTaurenVine:
                        return OrcBuildingTheTaurenVineConfig.MaxLevel;
                    case BuildingType.Orc_TrollHouse:
                        return OrcBuildingTrollHouseConfig.MaxLevel;
                    case BuildingType.Orc_WarriorHall:
                        return OrcBuildingWarriorHallConfig.MaxLevel;
                    case BuildingType.Orc_WyvernCamp:
                        return OrcBuildingWyvernCampConfig.MaxLevel;
                }
                break;
        }
        return 0;
    }

    public static ActorType GetProducedActorType(
        RaceType raceType,
        BuildingType buildingType,
        BuildingLevel buildingLevel)
    {
        switch (raceType)
        {
            case RaceType.Terran:
                switch (buildingType)
                {
                    case BuildingType.Terran_Barrack:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingBarrackConfig.ProducedActorTypeLevel1
                                   : TerranBuildingBarrackConfig.ProducedActorTypeLevel2;
                    case BuildingType.Terran_SniperHouse:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingSniperHouseConfig.ProducedActorTypeLevel1
                                   : TerranBuildingSniperHouseConfig.ProducedActorTypeLevel2;
                    case BuildingType.Terran_ArtilleryLab:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingArtilleryLabConfig.ProducedActorTypeLevel1
                                   : TerranBuildingArtilleryLabConfig.ProducedActorTypeLevel2;
                    case BuildingType.Terran_MysterySchool:
                        return TerranBuildingMysterySchoolConfig.ProducedActorTypeLevel1;
                    case BuildingType.Terran_Aviary:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingAviaryConfig.ProducedActorTypeLevel1
                                   : TerranBuildingAviaryConfig.ProducedActorTypeLevel2;
                    case BuildingType.Terran_Fortress:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingFortressConfig.ProducedActorTypeLevel1
                                   : TerranBuildingFortressConfig.ProducedActorTypeLevel2;
                    case BuildingType.Terran_Church:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingChurchConfig.ProducedActorTypeLevel1
                                   : TerranBuildingChurchConfig.ProducedActorTypeLevel2;
                    case BuildingType.Terran_Temple:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? TerranBuildingTempleConfig.ProducedActorTypeLevel1
                                   : TerranBuildingTempleConfig.ProducedActorTypeLevel2;
                }
                break;
            case RaceType.Orc:
                switch (buildingType)
                {
                    case BuildingType.Orc_AnimalFarm:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingAnimalFarmConfig.ProducedActorTypeLevel1
                                   : OrcBuildingAnimalFarmConfig.ProducedActorTypeLevel2;
                    case BuildingType.Orc_OrcFactory:
                        return OrcBuildingOrcFactoryConfig.ProducedActorTypeLevel1;
                    case BuildingType.Orc_ShamanTent:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingShamanTentConfig.ProducedActorTypeLevel1
                                   : OrcBuildingShamanTentConfig.ProducedActorTypeLevel2;
                    case BuildingType.Orc_ThePound:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingThePoundConfig.ProducedActorTypeLevel1
                                   : OrcBuildingThePoundConfig.ProducedActorTypeLevel2;
                    case BuildingType.Orc_TheTaurenVine:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingTheTaurenVineConfig.ProducedActorTypeLevel1
                                   : OrcBuildingTheTaurenVineConfig.ProducedActorTypeLevel2;
                    case BuildingType.Orc_TrollHouse:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingTrollHouseConfig.ProducedActorTypeLevel1
                                   : OrcBuildingTrollHouseConfig.ProducedActorTypeLevel2;
                    case BuildingType.Orc_WarriorHall:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingWarriorHallConfig.ProducedActorTypeLevel1
                                   : OrcBuildingWarriorHallConfig.ProducedActorTypeLevel2;
                    case BuildingType.Orc_WyvernCamp:
                        return buildingLevel == BuildingLevel.BuildingLevel1
                                   ? OrcBuildingWyvernCampConfig.ProducedActorTypeLevel1
                                   : OrcBuildingWyvernCampConfig.ProducedActorTypeLevel2;
                }
                break;
        }
        return 0;
    }

    public static int GetProducedTime(RaceType raceType, BuildingType buildingType, BuildingLevel buildingLevel)
    {
        if (raceType == RaceType.Terran)
        {
            switch (buildingType)
            {
                case BuildingType.Terran_Barrack:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? TerranBuildingBarrackConfig.ProducedTimeLevel1
                               : TerranBuildingBarrackConfig.ProducedTimeLevel2;
                case BuildingType.Terran_SniperHouse:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? TerranBuildingSniperHouseConfig.ProducedTimeLevel1
                               : TerranBuildingSniperHouseConfig.ProducedTimeLevel2;
                case BuildingType.Terran_ArtilleryLab:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? TerranBuildingArtilleryLabConfig.ProducedTimeLevel1
                               : TerranBuildingArtilleryLabConfig.ProducedTimeLevel2;
                case BuildingType.Terran_MysterySchool:
                    return TerranBuildingMysterySchoolConfig.ProducedTimeLevel1;
                case BuildingType.Terran_Aviary:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? TerranBuildingAviaryConfig.ProducedTimeLevel1
                               : TerranBuildingAviaryConfig.ProducedTimeLevel2;
                case BuildingType.Terran_Fortress:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? TerranBuildingFortressConfig.ProducedTimeLevel1
                               : TerranBuildingFortressConfig.ProducedTimeLevel2;
                case BuildingType.Terran_Church:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? TerranBuildingChurchConfig.ProducedTimeLevel1
                               : TerranBuildingChurchConfig.ProducedTimeLevel2;
                case BuildingType.Terran_Temple:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? TerranBuildingTempleConfig.ProducedTimeLevel1
                               : TerranBuildingTempleConfig.ProducedTimeLevel2;
            }
        }
        else if (raceType == RaceType.Orc)
        {
            switch (buildingType)
            {
                case BuildingType.Orc_AnimalFarm:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? OrcBuildingAnimalFarmConfig.ProducedTimeLevel1
                               : OrcBuildingAnimalFarmConfig.ProducedTimeLevel2;
                case BuildingType.Orc_OrcFactory:
                    return OrcBuildingOrcFactoryConfig.ProducedTimeLevel1;
                case BuildingType.Orc_ShamanTent:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? OrcBuildingShamanTentConfig.ProducedTimeLevel1
                               : OrcBuildingShamanTentConfig.ProducedTimeLevel2;
                case BuildingType.Orc_ThePound:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? OrcBuildingThePoundConfig.ProducedTimeLevel1
                               : OrcBuildingThePoundConfig.ProducedTimeLevel2;
                case BuildingType.Orc_TheTaurenVine:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? OrcBuildingTheTaurenVineConfig.ProducedTimeLevel1
                               : OrcBuildingTheTaurenVineConfig.ProducedTimeLevel2;
                case BuildingType.Orc_TrollHouse:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? OrcBuildingTrollHouseConfig.ProducedTimeLevel1
                               : OrcBuildingTrollHouseConfig.ProducedTimeLevel2;
                case BuildingType.Orc_WarriorHall:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? OrcBuildingWarriorHallConfig.ProducedTimeLevel1
                               : OrcBuildingWarriorHallConfig.ProducedTimeLevel2;
                case BuildingType.Orc_WyvernCamp:
                    return buildingLevel == BuildingLevel.BuildingLevel1
                               ? OrcBuildingWyvernCampConfig.ProducedTimeLevel1
                               : OrcBuildingWyvernCampConfig.ProducedTimeLevel2;
            }
        }
        return 0;
    }

    #endregion
}

/// <summary>
///     人族
/// </summary>
public static class TerranBuildingBarrackConfig
{
    #region Static Fields

    public static string BuildingName = "兵营";

    public static BuildingType BuildingType = BuildingType.Terran_Barrack;

    public static int CoinCostLevel1 = 100;

    public static int CoinCostLevel2 = 175;

    public static int HpLevel1 = 1200;

    public static int HpLevel2 = 1300;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.Infantry;

    public static ActorType ProducedActorTypeLevel2 = ActorType.Supporter;

    public static int ProducedTimeLevel1 = 20;

    public static int ProducedTimeLevel2 = 20;

    public static RaceType RaceType = RaceType.Terran;

    #endregion
}

public static class TerranBuildingSniperHouseConfig
{
    #region Static Fields

    public static string BuildingName = "狙击兵小屋";

    public static BuildingType BuildingType = BuildingType.Terran_SniperHouse;

    public static int CoinCostLevel1 = 140;

    public static int CoinCostLevel2 = 160;

    public static int HpLevel1 = 1200;

    public static int HpLevel2 = 1300;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.Sniper;

    public static ActorType ProducedActorTypeLevel2 = ActorType.Marksman;

    public static int ProducedTimeLevel1 = 22;

    public static int ProducedTimeLevel2 = 32;

    public static RaceType RaceType = RaceType.Terran;

    #endregion
}

public static class TerranBuildingArtilleryLabConfig
{
    #region Static Fields

    public static string BuildingName = "火炮实验室";

    public static BuildingType BuildingType = BuildingType.Terran_ArtilleryLab;

    public static int CoinCostLevel1 = 180;

    public static int CoinCostLevel2 = 210;

    public static int HpLevel1 = 1300;

    public static int HpLevel2 = 1200;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.HeavyGunner;

    public static ActorType ProducedActorTypeLevel2 = ActorType.MortarTeam;

    public static int ProducedTimeLevel1 = 31;

    public static int ProducedTimeLevel2 = 25;

    public static RaceType RaceType = RaceType.Terran;

    #endregion
}

public static class TerranBuildingMysterySchoolConfig
{
    #region Static Fields

    public static string BuildingName = "神秘学院";

    public static BuildingType BuildingType = BuildingType.Terran_MysterySchool;

    public static int CoinCostLevel1 = 300;

    public static int HpLevel1 = 1300;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel1;

    public static ActorType ProducedActorTypeLevel1 = ActorType.Warlock;

    public static int ProducedTimeLevel1 = 30;

    public static RaceType RaceType = RaceType.Terran;

    #endregion
}

public static class TerranBuildingAviaryConfig
{
    #region Static Fields

    public static string BuildingName = "狮鹫笼";

    public static BuildingType BuildingType = BuildingType.Terran_Aviary;

    public static int CoinCostLevel1 = 250;

    public static int CoinCostLevel2 = 200;

    public static int HpLevel1 = 1200;

    public static int HpLevel2 = 1400;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.GryphonRider;

    public static ActorType ProducedActorTypeLevel2 = ActorType.SeniorGryphonRider;

    public static int ProducedTimeLevel1 = 28;

    public static int ProducedTimeLevel2 = 32;

    public static RaceType RaceType = RaceType.Terran;

    #endregion
}

public static class TerranBuildingFortressConfig
{
    #region Static Fields

    public static string BuildingName = "要塞";

    public static BuildingType BuildingType = BuildingType.Terran_Fortress;

    public static int CoinCostLevel1 = 280;

    public static int CoinCostLevel2 = 230;

    public static int HpLevel1 = 1200;

    public static int HpLevel2 = 1500;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.Crusader;

    public static ActorType ProducedActorTypeLevel2 = ActorType.TemplarWarrior;

    public static int ProducedTimeLevel1 = 29;

    public static int ProducedTimeLevel2 = 36;

    public static RaceType RaceType = RaceType.Terran;

    #endregion
}

public static class TerranBuildingChurchConfig
{
    #region Static Fields

    public static string BuildingName = "教堂";

    public static BuildingType BuildingType = BuildingType.Terran_Church;

    public static int CoinCostLevel1 = 350;

    public static int CoinCostLevel2 = 300;

    public static int HpLevel1 = 1200;

    public static int HpLevel2 = 1500;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.Pastor;

    public static ActorType ProducedActorTypeLevel2 = ActorType.Sage;

    public static int ProducedTimeLevel1 = 30;

    public static int ProducedTimeLevel2 = 32;

    public static RaceType RaceType = RaceType.Terran;

    #endregion
}

public static class TerranBuildingTempleConfig
{
    #region Static Fields

    public static string BuildingName = "宫殿";

    public static BuildingType BuildingType = BuildingType.Terran_Temple;

    public static int CoinCostLevel1 = 400;

    public static int CoinCostLevel2 = 350;

    public static int HpLevel1 = 1200;

    public static int HpLevel2 = 1600;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.Knight;

    public static ActorType ProducedActorTypeLevel2 = ActorType.Paladin;

    public static int ProducedTimeLevel1 = 40;

    public static int ProducedTimeLevel2 = 40;

    public static RaceType RaceType = RaceType.Terran;

    #endregion
}

/// <summary>
///     兽族
/// </summary>
public static class OrcBuildingAnimalFarmConfig
{
    #region Static Fields

    public static string BuildingName = "野兽农场";

    public static BuildingType BuildingType = BuildingType.Orc_AnimalFarm;

    public static int CoinCostLevel1 = 260;

    public static int CoinCostLevel2 = 140;

    public static int HpLevel1 = 1200;

    public static int HpLevel2 = 1500;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.Raider;

    public static ActorType ProducedActorTypeLevel2 = ActorType.Kodo;

    public static int ProducedTimeLevel1 = 28;

    public static int ProducedTimeLevel2 = 35;

    public static RaceType RaceType = RaceType.Orc;

    #endregion
}

public static class OrcBuildingOrcFactoryConfig
{
    #region Static Fields

    public static string BuildingName = "兽人攻城工厂";

    public static BuildingType BuildingType = BuildingType.Orc_OrcFactory;

    public static int CoinCostLevel1 = 380;

    public static int HpLevel1 = 1200;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel1;

    public static ActorType ProducedActorTypeLevel1 = ActorType.Catapult;

    public static int ProducedTimeLevel1 = 35;

    public static RaceType RaceType = RaceType.Orc;

    #endregion
}

public static class OrcBuildingShamanTentConfig
{
    #region Static Fields

    public static string BuildingName = "萨满帐篷";

    public static BuildingType BuildingType = BuildingType.Orc_ShamanTent;

    public static int CoinCostLevel1 = 200;

    public static int CoinCostLevel2 = 400;

    public static int HpLevel1 = 1200;

    public static int HpLevel2 = 1400;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.Shaman;

    public static ActorType ProducedActorTypeLevel2 = ActorType.WitchDoctor;

    public static int ProducedTimeLevel1 = 23;

    public static int ProducedTimeLevel2 = 40;

    public static RaceType RaceType = RaceType.Orc;

    #endregion
}

public static class OrcBuildingThePoundConfig
{
    #region Static Fields

    public static string BuildingName = "兽栏堡垒";

    public static BuildingType BuildingType = BuildingType.Orc_ThePound;

    public static int CoinCostLevel1 = 200;

    public static int CoinCostLevel2 = 200;

    public static int HpLevel1 = 1200;

    public static int HpLevel2 = 1300;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.BatRider;

    public static ActorType ProducedActorTypeLevel2 = ActorType.SeniorBatRider;

    public static int ProducedTimeLevel1 = 28;

    public static int ProducedTimeLevel2 = 30;

    public static RaceType RaceType = RaceType.Orc;

    #endregion
}

public static class OrcBuildingTheTaurenVineConfig
{
    #region Static Fields

    public static string BuildingName = "图藤";

    public static BuildingType BuildingType = BuildingType.Orc_TheTaurenVine;

    public static int CoinCostLevel1 = 400;

    public static int CoinCostLevel2 = 380;

    public static int HpLevel1 = 1500;

    public static int HpLevel2 = 1600;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.SpiritWalker;

    public static ActorType ProducedActorTypeLevel2 = ActorType.Tauren;

    public static int ProducedTimeLevel1 = 35;

    public static int ProducedTimeLevel2 = 40;

    public static RaceType RaceType = RaceType.Orc;

    #endregion
}

public static class OrcBuildingTrollHouseConfig
{
    #region Static Fields

    public static string BuildingName = "巨魔小屋";

    public static BuildingType BuildingType = BuildingType.Orc_TrollHouse;

    public static int CoinCostLevel1 = 200;

    public static int CoinCostLevel2 = 80;

    public static int HpLevel1 = 1200;

    public static int HpLevel2 = 1300;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.TrollBerserker;

    public static ActorType ProducedActorTypeLevel2 = ActorType.TrollHunter;

    public static int ProducedTimeLevel1 = 25;

    public static int ProducedTimeLevel2 = 29;

    public static RaceType RaceType = RaceType.Orc;

    #endregion
}

public static class OrcBuildingWarriorHallConfig
{
    #region Static Fields

    public static string BuildingName = "战士大厅";

    public static BuildingType BuildingType = BuildingType.Orc_WarriorHall;

    public static int CoinCostLevel1 = 110;

    public static int CoinCostLevel2 = 100;

    public static int HpLevel1 = 1200;

    public static int HpLevel2 = 1300;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.Grunt;

    public static ActorType ProducedActorTypeLevel2 = ActorType.OldGrunt;

    public static int ProducedTimeLevel1 = 20;

    public static int ProducedTimeLevel2 = 25;

    public static RaceType RaceType = RaceType.Orc;

    #endregion
}

public static class OrcBuildingWyvernCampConfig
{
    #region Static Fields

    public static string BuildingName = "双足飞龙营地";

    public static BuildingType BuildingType = BuildingType.Orc_WyvernCamp;

    public static int CoinCostLevel1 = 250;

    public static int CoinCostLevel2 = 220;

    public static int HpLevel1 = 1200;

    public static int HpLevel2 = 1500;

    public static BuildingLevel MaxLevel = BuildingLevel.BuildingLevel2;

    public static ActorType ProducedActorTypeLevel1 = ActorType.Wyvern;

    public static ActorType ProducedActorTypeLevel2 = ActorType.WindRider;

    public static int ProducedTimeLevel1 = 30;

    public static int ProducedTimeLevel2 = 26;

    public static RaceType RaceType = RaceType.Orc;

    #endregion
}