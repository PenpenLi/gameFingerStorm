public class ActorArmor
{
    #region Constructors and Destructors

    public ActorArmor(ActorArmorType armorType, float armorAmount)
    {
        this.ActorArmorType = armorType;
        this.ArmorAmount = armorAmount;
    }

    #endregion

    #region Public Properties

    public ActorArmorType ActorArmorType { get; set; }

    public float ArmorAmount { get; set; }

    #endregion
}