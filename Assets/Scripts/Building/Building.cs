public class Building
{
    #region Constructors and Destructors

    public Building(int id, BuildingType buildingType, FactionType factionType)
    {
        this.BuildingId = id;
        this.BuildingType = buildingType;
        this.FactionType = factionType;
        this.CurrentLevel = BuildingLevel.BuildingLevel1;
        this.Race = BuildingsConfig.GetBuildingRaceType(this.BuildingType);
        this.MaxLevel = BuildingsConfig.GetMaxLevel(this.Race, this.BuildingType);
		this.BuildingName = BuildingsConfig.GetBuildingName(this.Race, this.BuildingType);
        this.CoinCostLevel1 = BuildingsConfig.GetCoinCost(this.Race, this.BuildingType, BuildingLevel.BuildingLevel1);
        this.CoinCostLevel2 = BuildingsConfig.GetCoinCost(this.Race, this.BuildingType, BuildingLevel.BuildingLevel2);
        this.TotalHpLevel1 = BuildingsConfig.GetHp(this.Race, this.BuildingType, BuildingLevel.BuildingLevel1);
        this.TotalHpLevel2 = BuildingsConfig.GetHp(this.Race, this.BuildingType, BuildingLevel.BuildingLevel2);
        this.ProducedActorTypeLevel1 = BuildingsConfig.GetProducedActorType(
            this.Race,
            this.BuildingType,
            BuildingLevel.BuildingLevel1);
        this.ProducedActorTypeLevel2 = BuildingsConfig.GetProducedActorType(
            this.Race,
            this.BuildingType,
            BuildingLevel.BuildingLevel2);
        this.ProducedTimeLevel1 = BuildingsConfig.GetProducedTime(
            this.Race,
            this.BuildingType,
            BuildingLevel.BuildingLevel1);
        this.ProducedTimeLevel2 = BuildingsConfig.GetProducedTime(
            this.Race,
            this.BuildingType,
            BuildingLevel.BuildingLevel2);

        this.CurrentHp = this.CurrentLevel == BuildingLevel.BuildingLevel1 ? this.TotalHpLevel1 : this.TotalHpLevel2;
        if (this.BuildingType == BuildingType.Terran_TheMainCity || this.BuildingType == BuildingType.Orc_TheMainCity)
        {
            this.IsMainCity = true;
        }
        else
        {
            this.IsMainCity = false;
        }
    }

    #endregion

    #region Public Properties

    public int BuildingId { get; set; }

    public string BuildingName { get; set; }

    public BuildingType BuildingType { get; set; }

    public int CoinCostLevel1 { get; set; }

    public int CoinCostLevel2 { get; set; }

    public float CurrentHp { get; set; }

    public BuildingLevel CurrentLevel { get; set; }

    public FactionType FactionType { get; set; }

    public bool IsMainCity { get; set; }

    public BuildingLevel MaxLevel { get; set; }

    public ActorType ProducedActorTypeLevel1 { get; set; }

    public ActorType ProducedActorTypeLevel2 { get; set; }

    public int ProducedTimeLevel1 { get; set; }

    public int ProducedTimeLevel2 { get; set; }

    public RaceType Race { get; set; }

    public int TotalHp
    {
        get
        {
            return this.CurrentLevel == BuildingLevel.BuildingLevel1 ? this.TotalHpLevel1 : this.TotalHpLevel2;
        }
    }

    #endregion

    #region Properties

    private int TotalHpLevel1 { get; set; }

    private int TotalHpLevel2 { get; set; }

    #endregion
}