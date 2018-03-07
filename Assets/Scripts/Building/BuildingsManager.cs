#region

using System.Collections.Generic;
using System.ComponentModel;

using AnimationOrTween;

using UnityEngine;

#endregion

public class BuildingsManager
{
    #region Static Fields

    private static object _lock = new object();

    private static BuildingsManager instance;

    #endregion

    #region Fields

    private Dictionary<int, GameObject> allBuildingsDictionary = new Dictionary<int, GameObject>();

    private Dictionary<FactionType, GameObject> baseBuildingDictionary = new Dictionary<FactionType, GameObject>();
	
	private int buildingIdSeq;

    #endregion

    #region Constructors and Destructors

    private BuildingsManager()
    {
    }

    #endregion

    #region Public Methods and Operators

    public static BuildingsManager GetInstance()
    {
        if (instance == null)
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new BuildingsManager();
                }
            }
        }
        return instance;
    }
	
	public GameObject CreateNewBuilding(BuildingType buildingType, FactionType factionType, Vector3 pos)
    {
        GameObject buildingObj = (GameObject)Object.Instantiate(Resources.Load("GameScene/Building"));
        buildingObj.name = "Building";
        buildingObj.transform.localScale = new Vector3(1, 1, 1);
        buildingObj.transform.position = pos;
        BuildingController buildingCtrl = buildingObj.GetComponent<BuildingController>();
        buildingCtrl.Building = new Building(this.GenerateNewBuildingId(), buildingType, factionType);
        if (buildingCtrl.Building.IsMainCity)
        {
            this.baseBuildingDictionary.Add(factionType, buildingObj);
        }
        this.allBuildingsDictionary.Add(buildingCtrl.Building.BuildingId, buildingObj);
		return buildingObj;
    }

    public void DestroyAllBuildings()
    {
        List<GameObject> allBuildings = new List<GameObject>();
        allBuildings.AddRange(this.allBuildingsDictionary.Values);
        for (int i = 0; i < allBuildings.Count; i++)
        {
            GameObject building = allBuildings[i];
            if (building != null)
            {
                BuildingController buildingCtrl = building.GetComponent<BuildingController>();
                buildingCtrl.DestroySelf();
            }
        }
        this.allBuildingsDictionary.Clear();
        this.baseBuildingDictionary.Clear();
        this.buildingIdSeq = 0;
    }
	
	public void DestroyBuilding(GameObject building)
	{
		BuildingController buildingCtrl = building.GetComponent<BuildingController>();
		if(buildingCtrl != null)
		{
			this.allBuildingsDictionary.Remove(buildingCtrl.Building.BuildingId);
			if(this.baseBuildingDictionary.ContainsValue(building))
				this.baseBuildingDictionary.Remove(buildingCtrl.Building.FactionType);
			buildingCtrl.DestroySelf();
		}
	}

    public GameObject GetBaseBuildingOfFaction(FactionType faction)
    {
        GameObject baseBuilding = null;
        if (this.baseBuildingDictionary != null)
        {
            if (this.baseBuildingDictionary.ContainsKey(faction))
            {
                baseBuilding = this.baseBuildingDictionary[faction];
            }
        }
        return baseBuilding;
    }

    public Dictionary<FactionType, GameObject> GetAllBaseBuildings ()
    {
        return new Dictionary<FactionType, GameObject>(this.baseBuildingDictionary);
    }

    public List<GameObject> GetAllEnemyBuildings(FactionType factionType)
	{
		List<GameObject> result = new List<GameObject>(this.allBuildingsDictionary.Values);
		for(int i = 0; i < result.Count; i ++)
		{
			BuildingController buildingCtrl = result[i].GetComponent<BuildingController>();
			if(buildingCtrl.Building.FactionType == factionType)
				result.RemoveAt(i);
		}
		return result;
	}

    public List<GameObject> GetAllBuildings()
    {
        return new List<GameObject>(this.allBuildingsDictionary.Values);
    }
	
	public List<GameObject> GetBuildingsOfFaction(FactionType factionType)
	{
		List<GameObject> result = new List<GameObject>(this.allBuildingsDictionary.Values);
		for(int i = 0; i < result.Count; i ++)
		{
			BuildingController buildingCtrl = result[i].GetComponent<BuildingController>();
			if(buildingCtrl.Building.FactionType != factionType)
				result.RemoveAt(i);
		}
		return result;
	}

    public List<GameObject> GetEnemyBuildingsInDistanceAndSortByDistance(BaseGameEntity gameEntity, float distance)
    {
        List<GameObject> result = new List<GameObject>();
        foreach (KeyValuePair<int, GameObject> kv in this.allBuildingsDictionary)
        {
            BuildingController buildingCtrl = kv.Value.GetComponent<BuildingController>();
            FactionType faction;
            if (gameEntity.GetType().IsInstanceOfType(typeof(BuildingController)))
            {
                faction = ((BuildingController)gameEntity).Building.FactionType;
            }
            else
            {
                faction = ((ActorController)gameEntity).MyActor.FactionType;
            }
            if (buildingCtrl.Building.FactionType != faction)
            {
                if ((kv.Value.transform.position - gameEntity.transform.position).sqrMagnitude <= Mathf.Pow(distance, 2))
                {
                    result.Add(kv.Value);
                }
            }
        }
        
        result.Sort(
            ( obj1, obj2 ) =>
            (obj1.transform.position - gameEntity.transform.position).sqrMagnitude.CompareTo(
                (obj2.transform.position - gameEntity.transform.position).sqrMagnitude));
        return result;
    }

    public GameObject GetBuildingById(int buildingId)
    {
        if (this.allBuildingsDictionary.ContainsKey(buildingId))
        {
            return this.allBuildingsDictionary[buildingId];
        }
        return null;
    }

    private int GenerateNewBuildingId()
    {
        int result;
        lock (_lock)
        {
            result = (++ this.buildingIdSeq);
        }
        return result;
    }
	
	public bool PayForTheBuilding(int buildingCost)
	{
		GameObject gameScene = GameObject.Find("GameSceneController");
		if(gameScene != null)
		{
			GameSceneController gameSceneCtrl = gameScene.GetComponent<GameSceneController>();
			if(gameSceneCtrl.CoinCount >= buildingCost)
			{
				gameSceneCtrl.CoinCount -= buildingCost;
				return true;
			}
		}
		return false;
	}

    #endregion
}