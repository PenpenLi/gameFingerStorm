#region

using UniLua;

using UnityEngine;

#endregion

public class LoadConfigOfLua : MonoBehaviour
{
    #region Static Fields

    private static ILuaState Lua;

    #endregion

    #region Methods

    private void CacheToGlobalConfig()
    {
        GlobalConfig.TerranActorCrusaderArmorType = this.GetFieldValueOfString("TerranActorCrusaderArmorType");
        GlobalConfig.TerranActorCrusaderAttackRange = this.GetFieldValueOfInt("TerranActorCrusaderAttackRange");
        GlobalConfig.TerranActorCrusaderAttackType = this.GetFieldValueOfString("TerranActorCrusaderAttackType");
        GlobalConfig.TerranActorCrusaderDef = this.GetFieldValueOfInt("TerranActorCrusaderDef");
        GlobalConfig.TerranActorCrusaderDps = this.GetFieldValueOfInt("TerranActorCrusaderDps");
        GlobalConfig.TerranActorCrusaderHp = this.GetFieldValueOfInt("TerranActorCrusaderHp");
        GlobalConfig.TerranActorCrusaderSpell = this.GetFieldValueOfString("TerranActorCrusaderSpell");

        GlobalConfig.TerranActorGryphonRiderArmorType = this.GetFieldValueOfString("TerranActorGryphonRiderArmorType");
        GlobalConfig.TerranActorGryphonRiderAttackType = this.GetFieldValueOfString("TerranActorGryphonRiderAttackType");
        GlobalConfig.TerranActorGryphonRiderDef = this.GetFieldValueOfInt("TerranActorGryphonRiderDef");
        GlobalConfig.TerranActorGryphonRiderDps = this.GetFieldValueOfInt("TerranActorGryphonRiderDps");
        GlobalConfig.TerranActorGryphonRiderHp = this.GetFieldValueOfInt("TerranActorGryphonRiderHp");
        GlobalConfig.TerranActorGryphonRiderSpell = this.GetFieldValueOfString("TerranActorGryphonRiderSpell");

        GlobalConfig.TerranActorHeavyGunnerArmorType = this.GetFieldValueOfString("TerranActorHeavyGunnerArmorType");
        GlobalConfig.TerranActorHeavyGunnerAttackRange = this.GetFieldValueOfInt("TerranActorHeavyGunnerAttackRange");
        GlobalConfig.TerranActorHeavyGunnerAttackType = this.GetFieldValueOfString("TerranActorHeavyGunnerAttackType");
        GlobalConfig.TerranActorHeavyGunnerDef = this.GetFieldValueOfInt("TerranActorHeavyGunnerDef");
        GlobalConfig.TerranActorHeavyGunnerDps = this.GetFieldValueOfInt("TerranActorHeavyGunnerDps");
        GlobalConfig.TerranActorHeavyGunnerHp = this.GetFieldValueOfInt("TerranActorHeavyGunnerHp");
        GlobalConfig.TerranActorHeavyGunnerSpell = this.GetFieldValueOfString("TerranActorHeavyGunnerSpell");

        GlobalConfig.TerranActorInfantryArmorType = this.GetFieldValueOfString("TerranActorInfantryArmorType");
        GlobalConfig.TerranActorInfantryAttackRange = this.GetFieldValueOfInt("TerranActorInfantryAttackRange");
        GlobalConfig.TerranActorInfantryAttackType = this.GetFieldValueOfString("TerranActorInfantryAttackType");
        GlobalConfig.TerranActorInfantryDef = this.GetFieldValueOfInt("TerranActorInfantryDef");
        GlobalConfig.TerranActorInfantryDps = this.GetFieldValueOfInt("TerranActorInfantryDps");
        GlobalConfig.TerranActorInfantryHp = this.GetFieldValueOfInt("TerranActorInfantryHp");
        GlobalConfig.TerranActorInfantrySpell = this.GetFieldValueOfString("TerranActorInfantrySpell");

        GlobalConfig.TerranActorMarksmanArmorType = this.GetFieldValueOfString("TerranActorMarksmanArmorType");
        GlobalConfig.TerranActorMarksmanAttackRange = this.GetFieldValueOfInt("TerranActorMarksmanAttackRange");
        GlobalConfig.TerranActorMarksmanAttackType = this.GetFieldValueOfString("TerranActorMarksmanAttackType");
        GlobalConfig.TerranActorMarksmanDef = this.GetFieldValueOfInt("TerranActorMarksmanDef");
        GlobalConfig.TerranActorMarksmanDps = this.GetFieldValueOfInt("TerranActorMarksmanDps");
        GlobalConfig.TerranActorMarksmanHp = this.GetFieldValueOfInt("TerranActorMarksmanHp");
        GlobalConfig.TerranActorMarksmanSpell = this.GetFieldValueOfString("TerranActorMarksmanSpell");

        GlobalConfig.TerranActorMortarTeamArmorType = this.GetFieldValueOfString("TerranActorMortarTeamArmorType");
        GlobalConfig.TerranActorMortarTeamAttackRange = this.GetFieldValueOfInt("TerranActorMortarTeamAttackRange");
        GlobalConfig.TerranActorMortarTeamAttackType = this.GetFieldValueOfString("TerranActorMortarTeamAttackType");
        GlobalConfig.TerranActorMortarTeamDef = this.GetFieldValueOfInt("TerranActorMortarTeamDef");
        GlobalConfig.TerranActorMortarTeamDps = this.GetFieldValueOfInt("TerranActorMortarTeamDps");
        GlobalConfig.TerranActorMortarTeamHp = this.GetFieldValueOfInt("TerranActorMortarTeamHp");
        GlobalConfig.TerranActorMortarTeamSpell = this.GetFieldValueOfString("TerranActorMortarTeamSpell");

        GlobalConfig.TerranActorSeniorGryphonRiderArmorType =
            this.GetFieldValueOfString("TerranActorSeniorGryphonRiderArmorType");
        GlobalConfig.TerranActorSeniorGryphonRiderAttackRange =
            this.GetFieldValueOfInt("TerranActorSeniorGryphonRiderAttackRange");
        GlobalConfig.TerranActorSeniorGryphonRiderAttackType =
            this.GetFieldValueOfString("TerranActorSeniorGryphonRiderAttackType");
        GlobalConfig.TerranActorSeniorGryphonRiderDef = this.GetFieldValueOfInt("TerranActorSeniorGryphonRiderDef");
        GlobalConfig.TerranActorSeniorGryphonRiderDps = this.GetFieldValueOfInt("TerranActorSeniorGryphonRiderDps");
        GlobalConfig.TerranActorSeniorGryphonRiderHp = this.GetFieldValueOfInt("TerranActorSeniorGryphonRiderHp");
        GlobalConfig.TerranActorSeniorGryphonRiderSpell =
            this.GetFieldValueOfString("TerranActorSeniorGryphonRiderSpell");

        GlobalConfig.TerranActorSniperArmorType = this.GetFieldValueOfString("TerranActorSniperArmorType");
        GlobalConfig.TerranActorSniperAttackRange = this.GetFieldValueOfInt("TerranActorSniperAttackRange");
        GlobalConfig.TerranActorSniperAttackType = this.GetFieldValueOfString("TerranActorSniperAttackType");
        GlobalConfig.TerranActorSniperDef = this.GetFieldValueOfInt("TerranActorSniperDef");
        GlobalConfig.TerranActorSniperDps = this.GetFieldValueOfInt("TerranActorSniperDps");
        GlobalConfig.TerranActorSniperHp = this.GetFieldValueOfInt("TerranActorSniperHp");
        GlobalConfig.TerranActorSniperSpell = this.GetFieldValueOfString("TerranActorSniperSpell");

        GlobalConfig.TerranActorSupporterArmorType = this.GetFieldValueOfString("TerranActorSupporterArmorType");
        GlobalConfig.TerranActorSupporterAttackRange = this.GetFieldValueOfInt("TerranActorSupporterAttackRange");
        GlobalConfig.TerranActorSupporterAttackType = this.GetFieldValueOfString("TerranActorSupporterAttackType");
        GlobalConfig.TerranActorSupporterDef = this.GetFieldValueOfInt("TerranActorSupporterDef");
        GlobalConfig.TerranActorSupporterDps = this.GetFieldValueOfInt("TerranActorSupporterDps");
        GlobalConfig.TerranActorSupporterHp = this.GetFieldValueOfInt("TerranActorSupporterHp");
        GlobalConfig.TerranActorSupporterSpell = this.GetFieldValueOfString("TerranActorSupporterSpell");

        GlobalConfig.TerranActorTemplarWarriorArmorType =
            this.GetFieldValueOfString("TerranActorTemplarWarriorArmorType");
        GlobalConfig.TerranActorTemplarWarriorAttackRange =
            this.GetFieldValueOfInt("TerranActorTemplarWarriorAttackRange");
        GlobalConfig.TerranActorTemplarWarriorAttackType =
            this.GetFieldValueOfString("TerranActorTemplarWarriorAttackType");
        GlobalConfig.TerranActorTemplarWarriorDef = this.GetFieldValueOfInt("TerranActorTemplarWarriorDef");
        GlobalConfig.TerranActorTemplarWarriorDps = this.GetFieldValueOfInt("TerranActorTemplarWarriorDps");
        GlobalConfig.TerranActorTemplarWarriorHp = this.GetFieldValueOfInt("TerranActorTemplarWarriorHp");
        GlobalConfig.TerranActorTemplarWarriorSpell = this.GetFieldValueOfString("TerranActorTemplarWarriorSpell");

        GlobalConfig.TerranActorWarlockArmorType = this.GetFieldValueOfString("TerranActorWarlockArmorType");
        GlobalConfig.TerranActorWarlockAttackRange = this.GetFieldValueOfInt("TerranActorWarlockAttackRange");
        GlobalConfig.TerranActorWarlockAttackType = this.GetFieldValueOfString("TerranActorWarlockAttackType");
        GlobalConfig.TerranActorWarlockDef = this.GetFieldValueOfInt("TerranActorWarlockDef");
        GlobalConfig.TerranActorWarlockDps = this.GetFieldValueOfInt("TerranActorWarlockDps");
        GlobalConfig.TerranActorWarlockHp = this.GetFieldValueOfInt("TerranActorWarlockHp");
        GlobalConfig.TerranActorWarlockSpell = this.GetFieldValueOfString("TerranActorWarlockSpell");

        GlobalConfig.TerranBuildingAdvancedAviaryCoinCost =
            this.GetFieldValueOfInt("TerranBuildingAdvancedAviaryCoinCost");
        GlobalConfig.TerranBuildingAdvancedAviaryHp = this.GetFieldValueOfInt("TerranBuildingAdvancedAviaryHp");
        GlobalConfig.TerranBuildingAdvancedAviaryProducedActor =
            this.GetFieldValueOfString("TerranBuildingAdvancedAviaryProducedActor");
        GlobalConfig.TerranBuildingAdvancedAviaryProduceTime =
            this.GetFieldValueOfInt("TerranBuildingAdvancedAviaryProduceTime");

        GlobalConfig.TerranBuildingArtilleryHallCoinCost = this.GetFieldValueOfInt(
            "TerranBuildingArtilleryHallCoinCost");
        GlobalConfig.TerranBuildingArtilleryHallHp = this.GetFieldValueOfInt("TerranBuildingArtilleryHallHp");
        GlobalConfig.TerranBuildingArtilleryHallProducedActor =
            this.GetFieldValueOfString("TerranBuildingArtilleryHallProducedActor");
        GlobalConfig.TerranBuildingArtilleryHallProduceTime =
            this.GetFieldValueOfInt("TerranBuildingArtilleryHallProduceTime");

        GlobalConfig.TerranBuildingArtilleryLabCoinCost = this.GetFieldValueOfInt("TerranBuildingArtilleryLabCoinCost");
        GlobalConfig.TerranBuildingArtilleryLabHp = this.GetFieldValueOfInt("TerranBuildingArtilleryLabHp");
        GlobalConfig.TerranBuildingArtilleryLabProducedActor =
            this.GetFieldValueOfString("TerranBuildingArtilleryLabProducedActor");
        GlobalConfig.TerranBuildingArtilleryLabProduceTime =
            this.GetFieldValueOfInt("TerranBuildingArtilleryLabProduceTime");

        GlobalConfig.TerranBuildingAviaryCoinCost = this.GetFieldValueOfInt("TerranBuildingAviaryCoinCost");
        GlobalConfig.TerranBuildingAviaryHp = this.GetFieldValueOfInt("TerranBuildingAviaryHp");
        GlobalConfig.TerranBuildingAviaryProducedActor = this.GetFieldValueOfString("TerranBuildingAviaryProducedActor");
        GlobalConfig.TerranBuildingAviaryProduceTime = this.GetFieldValueOfInt("TerranBuildingAviaryProduceTime");

        GlobalConfig.TerranBuildingBarrackCoinCost = this.GetFieldValueOfInt("TerranBuildingBarrackCoinCost");
        GlobalConfig.TerranBuildingBarrackHp = this.GetFieldValueOfInt("TerranBuildingBarrackHp");
        GlobalConfig.TerranBuildingBarrackProducedActor =
            this.GetFieldValueOfString("TerranBuildingBarrackProducedActor");
        GlobalConfig.TerranBuildingBarrackProduceTime = this.GetFieldValueOfInt("TerranBuildingBarrackProduceTime");

        GlobalConfig.TerranBuildingChurchCoinCost = this.GetFieldValueOfInt("TerranBuildingChurchCoinCost");
        GlobalConfig.TerranBuildingChurchHp = this.GetFieldValueOfInt("TerranBuildingChurchHp");
        GlobalConfig.TerranBuildingChurchProducedActor = this.GetFieldValueOfString("TerranBuildingChurchProducedActor");
        GlobalConfig.TerranBuildingChurchProduceTime = this.GetFieldValueOfInt("TerranBuildingChurchProduceTime");

        GlobalConfig.TerranBuildingFortressCoinCost = this.GetFieldValueOfInt("TerranBuildingFortressCoinCost");
        GlobalConfig.TerranBuildingFortressHp = this.GetFieldValueOfInt("TerranBuildingFortressHp");
        GlobalConfig.TerranBuildingFortressProducedActor =
            this.GetFieldValueOfString("TerranBuildingFortressProducedActor");
        GlobalConfig.TerranBuildingFortressProduceTime = this.GetFieldValueOfInt("TerranBuildingFortressProduceTime");

        GlobalConfig.TerranBuildingMarksmanCampCoinCost = this.GetFieldValueOfInt("TerranBuildingMarksmanCampCoinCost");
        GlobalConfig.TerranBuildingMarksmanCampHp = this.GetFieldValueOfInt("TerranBuildingMarksmanCampHp");
        GlobalConfig.TerranBuildingMarksmanCampProducedActor =
            this.GetFieldValueOfString("TerranBuildingMarksmanCampProducedActor");
        GlobalConfig.TerranBuildingMarksmanCampProduceTime =
            this.GetFieldValueOfInt("TerranBuildingMarksmanCampProduceTime");

        GlobalConfig.TerranBuildingMysterySchoolCoinCost = this.GetFieldValueOfInt(
            "TerranBuildingMysterySchoolCoinCost");
        GlobalConfig.TerranBuildingMysterySchoolHp = this.GetFieldValueOfInt("TerranBuildingMysterySchoolHp");
        GlobalConfig.TerranBuildingMysterySchoolProducedActor =
            this.GetFieldValueOfString("TerranBuildingMysterySchoolProducedActor");
        GlobalConfig.TerranBuildingMysterySchoolProduceTime =
            this.GetFieldValueOfInt("TerranBuildingMysterySchoolProduceTime");

        GlobalConfig.TerranBuildingSniperHouseCoinCost = this.GetFieldValueOfInt("TerranBuildingSniperHouseCoinCost");
        GlobalConfig.TerranBuildingSniperHouseHp = this.GetFieldValueOfInt("TerranBuildingSniperHouseHp");
        GlobalConfig.TerranBuildingSniperHouseProducedActor =
            this.GetFieldValueOfString("TerranBuildingSniperHouseProducedActor");
        GlobalConfig.TerranBuildingSniperHouseProduceTime =
            this.GetFieldValueOfInt("TerranBuildingSniperHouseProduceTime");

        GlobalConfig.TerranBuildingTempleCoinCost = this.GetFieldValueOfInt("TerranBuildingTempleCoinCost");
        GlobalConfig.TerranBuildingTempleHp = this.GetFieldValueOfInt("TerranBuildingTempleHp");
        GlobalConfig.TerranBuildingTempleProducedActor = this.GetFieldValueOfString("TerranBuildingTempleProducedActor");
        GlobalConfig.TerranBuildingTempleProduceTime = this.GetFieldValueOfInt("TerranBuildingTempleProduceTime");
    }

    private int GetFieldValueOfInt(string fieldName)
    {
        Lua.GetField(1, fieldName);
        int result = Lua.ToInteger(-1);
        Lua.Pop(1);
        //Debug.Log(fieldName + " : " + result);
        return result;
    }

    private string GetFieldValueOfString(string fieldName)
    {
        Lua.GetField(1, fieldName);
        string result = null;
        if (Lua.IsString(-1))
        {
            result = Lua.ToString(-1);
        }
        else
        {
            Debug.LogError("Field Type Error!");
        }
        Lua.Pop(1);
        //Debug.Log(fieldName + " : " + result);
        return result;
    }

    private bool Load()
    {
        string LuaFile = "config.lua";
        Lua = LuaAPI.NewState();
        Lua.L_OpenLibs();
        ThreadStatus status = Lua.L_DoFile(LuaFile);
        if (status != ThreadStatus.LUA_OK)
        {
            Debug.LogError("Load Lua File Error!");
            return false;
        }
        if (!Lua.IsTable(-1))
        {
            Debug.LogError("Load Lua File Error!");
            return false;
        }
        this.CacheToGlobalConfig();
        return true;
    }

    private void Start()
    {
        if (this.Load())
        {
            Destroy(this.gameObject);
        }
    }

    #endregion
}