using System.Collections.Generic;

using UnityEngine;

public class GameResultChecker : MonoBehaviour
{
    private GameSceneController gameSceneController;

    private BuildingsManager buildingsManager;

    private ActorsManager actorsManager;

    private void Start()
    {
        this.gameSceneController = GameObject.Find("GameSceneController").GetComponent<GameSceneController>();
        this.buildingsManager = BuildingsManager.GetInstance();
        this.actorsManager = ActorsManager.GetInstance();
        this.InvokeRepeating("CheckResult", 0f, 0.1f);
    }

    private void CheckResult()
    {
        if (gameSceneController != null)
        {
            /*if (gameSceneController.IsArmageddon)
            {
                List<GameObject> myActors = this.actorsManager.GetActorsOfFaction(
                    this.gameSceneController.MyFactionType);
                if (myActors == null || myActors.Count == 0)
                {
                    this.gameSceneController.ShowGameResult(false);
                    if (this.gameSceneController.GameController.GameType == GameType.PVP)
                    {
                        this.gameSceneController.GameController.Client.SendGameResult();
                    }
                    this.DestroySelf();
                }
                List<GameObject> enemyActors =
                    this.actorsManager.GetAllEnemyActors(this.gameSceneController.MyFactionType);
                if (enemyActors == null || enemyActors.Count == 0)
                {
                    this.gameSceneController.ShowGameResult(true);
                    this.DestroySelf();
                }
            }
            else*/
            {
                Dictionary<FactionType, GameObject> allBaseBuildings = this.buildingsManager.GetAllBaseBuildings();
                if (allBaseBuildings != null && allBaseBuildings.Keys.Count == 1)
                {
                    if (!allBaseBuildings.ContainsKey(this.gameSceneController.MyFactionType))
                    {
                        this.gameSceneController.ShowGameResult(false);
                        if (this.gameSceneController.GameController.GameType == GameType.PVP)
                        {
                            this.gameSceneController.GameController.Client.SendGameResult();
                        }
                    }
                    else
                    {
                        this.gameSceneController.ShowGameResult(true);
                    }
                    this.DestroySelf();
                }
            }
        }
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}