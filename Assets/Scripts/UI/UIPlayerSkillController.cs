#region

using System.Collections.Generic;

using UnityEngine;

#endregion

public class UIPlayerSkillController : MonoBehaviour
{
    #region Fields

    private GameSceneController gameSceneController;

    private Transform myTranform;

    private bool toReleaseFireBall;

    #endregion

    #region Public Methods and Operators

    public void ReleaseBloodlust(FactionType releaseFaction)
    {
        List<GameObject> myActors = ActorsManager.GetInstance().GetActorsOfFaction(releaseFaction);
        myActors.ForEach(
            actor =>
                {
                    GameObject bloodlust = (GameObject)Instantiate(Resources.Load("GameScene/PlayerSkillBloodlust"));
                    bloodlust.name = "BloodLustRelease";
                    bloodlust.transform.parent = actor.transform;
                    bloodlust.transform.localPosition = new Vector3(0, 0, 0);
                    tk2dSpriteAnimator animator = bloodlust.GetComponent<tk2dSpriteAnimator>();
                    animator.Play("Release");
                    animator.AnimationCompleted = delegate
                        {
                            Destroy(bloodlust);
                            if (actor != null)
                            {
                                ActorController actorCtrl = actor.GetComponent<ActorController>();
                                actorCtrl.BloodSuckingRatio = 30;
                                actorCtrl.AttackPlusRatio = 1.5f;
                                GameObject bloodBustHalo =
                                    (GameObject)Instantiate(Resources.Load("GameScene/PlayerSkillBloodlust"));
                                bloodBustHalo.name = "BloodBustHalo";
                                bloodBustHalo.transform.parent = actor.transform;
                                bloodBustHalo.transform.localPosition = new Vector3(10,-5,0);
                                bloodBustHalo.GetComponent<tk2dSpriteAnimator>().Play("Halo");
                            }
                        };
                });
    }

    public void ReleaseFireBall(Vector3 pos, FactionType releaseFaction)
    {
        GameObject fireBall = (GameObject)Instantiate(Resources.Load("GameScene/PlayerSkillFireBall"));
        fireBall.transform.position = pos;
        tk2dSpriteAnimator animator = fireBall.GetComponent<tk2dSpriteAnimator>();
        animator.AnimationCompleted = delegate
            {
                Damage fireBallDamage = new Damage();
                fireBallDamage.DamageValue = 1000;
                fireBallDamage.ShowCrit = true;
                List<GameObject> enemies = ActorsManager.GetInstance().GetEnemyActorsInDistance(releaseFaction, pos, 50);
                enemies.ForEach(
                    enemy =>
                        {
                            if (enemy != null)
                            {
                                ActorController actorCtrl = enemy.GetComponent<ActorController>();
                                actorCtrl.TakeDamage(fireBallDamage);
                            }
                        });
                Destroy(fireBall);
            };
    }

    public void ReleaseHeal(FactionType releaseFaction)
    {
        Damage healDamage = new Damage();
        healDamage.DamageValue = -300;
        healDamage.ShowCrit = true;
        List<GameObject> myActors = ActorsManager.GetInstance().GetActorsOfFaction(releaseFaction);
        myActors.ForEach(
            actor =>
                {
                    GameObject heal = (GameObject)Instantiate(Resources.Load("GameScene/PlayerSkillHeal"));
                    heal.transform.parent = actor.transform;
                    heal.transform.localPosition = new Vector3(0, 0, 0);
                    tk2dSpriteAnimator animator = heal.GetComponent<tk2dSpriteAnimator>();
                    animator.AnimationCompleted = delegate
                        {
                            if (actor != null)
                            {
                                ActorController actorCtrl = actor.GetComponent<ActorController>();
                                actorCtrl.TakeDamage(healDamage);
                                Destroy(heal);
                            }
                        };
                });
    }

    public void ReleaseLightningBolt(FactionType releaseFaction)
    {
        Damage lightningBoltDamage = new Damage();
        lightningBoltDamage.DamageValue = 300;
        lightningBoltDamage.ShowCrit = true;
        List<GameObject> enemyActors = ActorsManager.GetInstance().GetAllEnemyActors(releaseFaction);
        enemyActors.ForEach(
            enemyActor =>
                {
                    GameObject lightningBolt =
                        (GameObject)Instantiate(Resources.Load("GameScene/PlayerSkillLightningBolt"));
                    lightningBolt.transform.parent = enemyActor.transform;
                    lightningBolt.transform.localPosition = new Vector3(0, 0, 0);
                    tk2dSpriteAnimator animator = lightningBolt.GetComponent<tk2dSpriteAnimator>();
                    animator.AnimationCompleted = delegate
                        {
                            if (enemyActor != null)
                            {
                                ActorController actorCtrl = enemyActor.GetComponent<ActorController>();
                                actorCtrl.TakeDamage(lightningBoltDamage);
                                Destroy(lightningBolt);
                            }
                        };
                });
    }

    public void ReleaseBraySurgery(FactionType releaseFaction)
    {

    }

    #endregion

    #region Methods

    private void HandleEvent(GameObject eventObj)
    {
        switch (eventObj.name)
        {
            case "FireBall":
                if (this.gameSceneController.Mp >= 60)
                {
                    this.gameSceneController.Mp -= 60;
                    this.toReleaseFireBall = true;
                }
                break;
            case "LightningBolt":
                {
                    if (this.gameSceneController.Mp >= 90)
                    {
                        this.gameSceneController.Mp -= 90;
                        if (this.gameSceneController.GameController.GameType == GameType.PVP)
                        {
                            this.gameSceneController.GameController.Client.SendReleasePlayerSkill("LightningBolt", Vector3.zero);
                        }
                        this.ReleaseLightningBolt(this.gameSceneController.MyFactionType);
                    }
                    break;
                }
            case "BraySurgery":
                {
                    if (this.gameSceneController.Mp >= 6000000)
                    {
                        this.gameSceneController.Mp -= 60;
                    }
                    break;
                }
            case "Heal":
                {
                    if (this.gameSceneController.Mp >= 100)
                    {
                        this.gameSceneController.Mp -= 100;
                        if (this.gameSceneController.GameController.GameType == GameType.PVP)
                        {
                            this.gameSceneController.GameController.Client.SendReleasePlayerSkill("Heal", Vector3.zero);
                        }
                        this.ReleaseHeal(this.gameSceneController.MyFactionType);
                    }
                    break;
                }
            case "Bloodlust":
                {
                    if (this.gameSceneController.Mp >= 120)
                    {
                        this.gameSceneController.Mp -= 120;
                        if (this.gameSceneController.GameController.GameType == GameType.PVP)
                        {
                            this.gameSceneController.GameController.Client.SendReleasePlayerSkill("Bloodlust", Vector3.zero);
                        }
                        this.ReleaseBloodlust(this.gameSceneController.MyFactionType);
                    }
                    break;
                }
        }
    }

    private void OnTap(TapGesture gesture)
    {
        if (this.toReleaseFireBall)
        {
            Rect validRect = new Rect(0, 160, Screen.width, Screen.height - 160 - 50);
            if (validRect.Contains(gesture.Position))
            {
                this.toReleaseFireBall = false;
                if (this.gameSceneController.GameController.GameType == GameType.PVP)
                {
                    this.gameSceneController.GameController.Client.SendReleasePlayerSkill("FireBall", gesture.Position);
                }
                this.ReleaseFireBall(gesture.Position, this.gameSceneController.MyFactionType);
            }
        }
    }

    private void Start()
    {
        this.myTranform = this.transform;
        this.gameSceneController = GameObject.Find("GameSceneController").GetComponent<GameSceneController>();
        this.toReleaseFireBall = false;

        UIEventListener.Get(this.myTranform.FindChild("FireBall").gameObject).onClick = this.HandleEvent;
        UIEventListener.Get(this.myTranform.FindChild("LightningBolt").gameObject).onClick = this.HandleEvent;
        UIEventListener.Get(this.myTranform.FindChild("BraySurgery").gameObject).onClick = this.HandleEvent;
        UIEventListener.Get(this.myTranform.FindChild("Heal").gameObject).onClick = this.HandleEvent;
        UIEventListener.Get(this.myTranform.FindChild("Bloodlust").gameObject).onClick = this.HandleEvent;
    }

    #endregion
}