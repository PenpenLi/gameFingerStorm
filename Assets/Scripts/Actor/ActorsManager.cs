#region

using System.Collections.Generic;
using System.Linq;

using UnityEngine;

#endregion

public class ActorsManager
{
    #region Static Fields

    private static readonly object _lock = new object();

    private static ActorsManager instance;

    #endregion

    #region Fields

    private readonly Dictionary<int, GameObject> actorsDictionary = new Dictionary<int, GameObject>();

    private int actorIdSeq;

    #endregion

    #region Constructors and Destructors

    private ActorsManager()
    {
    }

    #endregion

    #region Public Methods and Operators

    public static ActorsManager GetInstance()
    {
        if (instance == null)
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new ActorsManager();
                }
            }
        }
        return instance;
    }

    public void CreateNewActor(FactionType factionType, RaceType raceType, ActorType actorType, Vector3 pos)
    {
        GameObject actorObj = (GameObject)Object.Instantiate(Resources.Load("GameScene/Actor"));
        int actorId = this.GenerateNewActorId();
        actorObj.transform.name = "Actor_" + actorId.ToString("D3");
        actorObj.transform.localScale = new Vector3(1, 1, 1);
        actorObj.transform.position = pos;
        ActorController actorCtrl = actorObj.GetComponent<ActorController>();
        Actor actor = new Actor(actorId, raceType, actorType, factionType);
        actorCtrl.TargetBuilding =
            BuildingsManager.GetInstance()
                .GetBaseBuildingOfFaction(actor.FactionType == FactionType.Blue ? FactionType.Red : FactionType.Blue);
        actorCtrl.ActorPath = ActorPathManager.GetInstance()
            .GenerateNewPath(pos, actorCtrl.TargetBuilding.transform.position);
        actorCtrl.MyActor = actor;
        this.actorsDictionary.Add(actorId, actorObj);
    }

    public void CreateNewActor(Actor actor, Vector3 pos)
    {
        GameObject actorObj = (GameObject)Object.Instantiate(Resources.Load("GameScene/Actor"));
        int actorId = this.GenerateNewActorId();
        actorObj.transform.name = "Actor_" + actorId.ToString("D3");
        actorObj.transform.localScale = new Vector3(1, 1, 1);
        actorObj.transform.position = pos;
        ActorController actorCtrl = actorObj.GetComponent<ActorController>();
        actor.ActorId = actorId;
        actorCtrl.TargetBuilding =
            BuildingsManager.GetInstance()
                .GetBaseBuildingOfFaction(actor.FactionType == FactionType.Blue ? FactionType.Red : FactionType.Blue);
        actorCtrl.ActorPath = ActorPathManager.GetInstance()
            .GenerateNewPath(pos, actorCtrl.TargetBuilding.transform.position);
        actorCtrl.MyActor = actor;
        this.actorsDictionary.Add(actorId, actorObj);
    }

    public void DestroyAllActors()
    {
        List<GameObject> allActors = new List<GameObject>();
        allActors.AddRange(this.actorsDictionary.Values);
        for (int i = 0; i < allActors.Count; i ++)
        {
            GameObject actor = allActors[i];
            if (actor != null)
            {
                ActorController actorCtrl = actor.GetComponent<ActorController>();
                actorCtrl.DestroySelf();
            }
        }
        this.actorsDictionary.Clear();
        this.actorIdSeq = 0;
    }

    public GameObject GetActorById(int actorId)
    {
        return this.actorsDictionary.ContainsKey(actorId) ? this.actorsDictionary[actorId] : null;
    }

    public List<GameObject> GetActorsOfFaction(FactionType factionType)
    {
        return (from kv in this.actorsDictionary
                let actorCtrl = kv.Value.GetComponent<ActorController>()
                where actorCtrl.MyActor.FactionType == factionType
                select kv.Value).ToList();
    }

    public List<GameObject> GetAirForceActorsOfFaction(FactionType factionType)
    {
        return (from kv in this.actorsDictionary
                let actorCtrl = kv.Value.GetComponent<ActorController>()
                where actorCtrl.MyActor.FactionType == factionType && actorCtrl.MyActor.IsAirForce
                select kv.Value).ToList();
    }

    public List<GameObject> GetAllActors()
    {
        return new List<GameObject>(this.actorsDictionary.Values.ToArray());
    }

    public List<GameObject> GetAllEnemyActors(FactionType factionType)
    {
        return (from kv in this.actorsDictionary
                where kv.Value != null
                let actorCtrl = kv.Value.GetComponent<ActorController>()
                where actorCtrl.MyActor.FactionType != factionType
                select kv.Value).ToList();
    }

    public List<GameObject> GetEnemyActorsInDistance(
        ActorController actorController,
        int distance,
        bool ignoreObstacles = true)
    {
        List<GameObject> result = (from kv in this.actorsDictionary
                                   let actorCtrl = kv.Value.GetComponent<ActorController>()
                                   where actorCtrl.MyActor.FactionType != actorController.MyActor.FactionType
                                   where
                                       (actorController.gameObject.transform.position - kv.Value.transform.position)
                                           .sqrMagnitude <= Mathf.Pow(distance, 2)
                                   select kv.Value).ToList();
        if (!ignoreObstacles)
        {
            for (int i = 0; i < result.Count; i ++)
            {
                GameObject enemy = result[i];
                RaycastHit hit;
                if (Physics.Raycast(enemy.transform.position, actorController.gameObject.transform.position, out hit))
                {
                    if (hit.collider.gameObject.tag.Equals("Obstacle"))
                    {
                        result.RemoveAt(i);
                    }
                }
            }
        }
        return result;
    }

    public List<GameObject> GetEnemyActorsInDistance(
        FactionType factionType,
        Vector3 position,
        int distance,
        bool ignoreObstacles = true)
    {
        List<GameObject> result = (from kv in this.actorsDictionary
                                   let actorCtrl = kv.Value.GetComponent<ActorController>()
                                   where actorCtrl.MyActor.FactionType != factionType
                                   where (position - kv.Value.transform.position).sqrMagnitude <= Mathf.Pow(distance, 2)
                                   select kv.Value).ToList();
        if (!ignoreObstacles)
        {
            for (int i = 0; i < result.Count; i ++)
            {
                GameObject enemy = result[i];
                RaycastHit hit;
                if (Physics.Raycast(enemy.transform.position, position, out hit))
                {
                    if (hit.collider.gameObject.tag.Equals("Obstacle"))
                    {
                        result.RemoveAt(i);
                    }
                }
            }
        }
        return result;
    }

    public List<GameObject> GetEnemyActorsInDistanceAndSortByDistance(
        ActorController actorController,
        int distance,
        bool ignoreObstacles)
    {
        List<GameObject> result = (from kv in this.actorsDictionary
                                   let actorCtrl = kv.Value.GetComponent<ActorController>()
                                   where actorCtrl.MyActor.FactionType != actorController.MyActor.FactionType
                                   where
                                       (actorController.gameObject.transform.position - kv.Value.transform.position)
                                           .sqrMagnitude <= Mathf.Pow(distance, 2)
                                   select kv.Value).ToList();
        if (!ignoreObstacles)
        {
            for (int i = 0; i < result.Count; i ++)
            {
                GameObject enemy = result[i];
                RaycastHit hit;
                if (Physics.Raycast(enemy.transform.position, actorController.gameObject.transform.position, out hit))
                {
                    if (hit.collider.gameObject.tag.Equals("Obstacle"))
                    {
                        result.RemoveAt(i);
                    }
                }
            }
        }
        result.Sort(
            (actor1, actor2) =>
            (actor1.transform.position - actorController.gameObject.transform.position).sqrMagnitude.CompareTo(
                (actor2.transform.position - actorController.gameObject.transform.position).sqrMagnitude));
        return result;
    }

    public List<GameObject> GetEnemyAirForceActorsOfFaction(FactionType factionType)
    {
        return (from kv in this.actorsDictionary
                let actorCtrl = kv.Value.GetComponent<ActorController>()
                where actorCtrl.MyActor.FactionType != factionType && actorCtrl.MyActor.IsAirForce
                select kv.Value).ToList();
    }

    public List<GameObject> GetEnemyAirForceActorsOfFactionInDistance(ActorController actorController, int distance)
    {
        return (from kv in this.actorsDictionary
                let actorCtrl = kv.Value.GetComponent<ActorController>()
                where
                    actorCtrl.MyActor.FactionType != actorController.MyActor.FactionType && actorCtrl.MyActor.IsAirForce
                where
                    (actorController.gameObject.transform.position - kv.Value.transform.position).sqrMagnitude
                    <= Mathf.Pow(distance, 2)
                select kv.Value).ToList();
    }

    public List<GameObject> GetFriendlyActorsInDistance(
        FactionType factionType,
        Vector3 position,
        int distance,
        bool ignoreObstacles = true)
    {
        List<GameObject> result = (from kv in this.actorsDictionary
                                   let actorCtrl = kv.Value.GetComponent<ActorController>()
                                   where actorCtrl.MyActor.FactionType == factionType
                                   where (position - kv.Value.transform.position).sqrMagnitude <= Mathf.Pow(distance, 2)
                                   select kv.Value).ToList();
        if (!ignoreObstacles)
        {
            for (int i = 0; i < result.Count; i++)
            {
                GameObject enemy = result[i];
                RaycastHit hit;
                if (Physics.Raycast(enemy.transform.position, position, out hit))
                {
                    if (hit.collider.gameObject.tag.Equals("Obstacle"))
                    {
                        result.RemoveAt(i);
                    }
                }
            }
        }
        return result;
    }

    public bool HasEnemyActorsInDistance(ActorController actorController, int distance)
    {
        return (from kv in this.actorsDictionary
                let actorCtrl = kv.Value.GetComponent<ActorController>()
                where actorCtrl.MyActor.FactionType != actorController.MyActor.FactionType
                select kv).Any(
                    kv =>
                    (actorController.gameObject.transform.position - kv.Value.transform.position).sqrMagnitude
                    <= Mathf.Pow(distance, 2));
    }

    public void RemoveActorById(int actorId)
    {
        if (this.actorsDictionary.ContainsKey(actorId))
        {
            this.actorsDictionary.Remove(actorId);
        }
    }

    #endregion

    #region Methods

    private int GenerateNewActorId()
    {
        int result;
        lock (_lock)
        {
            result = (++ this.actorIdSeq);
        }
        return result;
    }

    #endregion
}