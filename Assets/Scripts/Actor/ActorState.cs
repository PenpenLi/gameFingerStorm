#region

using System.Collections.Generic;
using System.Text;

using UnityEngine;

#endregion

public class Actor_GlobalState : State<ActorController>
{
    #region Fields

    private Dictionary<ActorSpellName, ActorSpell> activeSpellDictionary;

    private Dictionary<ActorSpellName, float> releaseCounterDictionary;

    private float shamanBlessCounter = 0f;

    private float poisionCounter = 0f;

    private float burningOilCounter = 0f;

    #endregion

    #region Public Methods and Operators

    public static Actor_GlobalState Instance()
    {
        return new Actor_GlobalState();
    }

    public override void Enter(ActorController entityType)
    {
        this.activeSpellDictionary = entityType.MyActor.GetSpellsByType(ActorSpellType.ActiveSpell);
        if (this.activeSpellDictionary != null)
        {
            this.releaseCounterDictionary = new Dictionary<ActorSpellName, float>();
            foreach (KeyValuePair<ActorSpellName, ActorSpell> kv in this.activeSpellDictionary)
            {
                this.releaseCounterDictionary.Add(kv.Key, 0f);
            }
        }
    }

    public override void Execute(ActorController entityType)
    {
        if (entityType.IsStun)
        {
            entityType.StunDuration -= Time.deltaTime;
            if (entityType.StunDuration <= 0)
            {
                entityType.IsStun = false;
                entityType.StunDuration = 0;
            }
            return;
        }

        if (entityType.IsBleed)
        {
            entityType.BleedDuration -= Time.deltaTime;
            Damage bleedDamage = new Damage();
            bleedDamage.DamageValue = entityType.BleedDps * Time.deltaTime;
            entityType.TakeDamage(bleedDamage);
            if (entityType.BleedDuration <= 0)
            {
                entityType.IsBleed = false;
                entityType.BleedDps = 0;
                entityType.BleedDuration = 0;
            }
        }

        if (entityType.IsRaging)
        {
            entityType.RagingDuration -= Time.deltaTime;
            if (entityType.RagingDuration <= 0)
            {
                entityType.IsRaging = false;
                entityType.RagingDuration = 0;
            }
        }

        if (entityType.IsShamanBlessing)
        {
            entityType.ShamanBlessingDuration -= Time.deltaTime;
            this.shamanBlessCounter += Time.deltaTime;
            if (this.shamanBlessCounter >= 1)
            {
                Damage blessDamage = new Damage();
                blessDamage.DamageValue = -3;
                blessDamage.ShowCrit = true;
                entityType.TakeDamage(blessDamage);
                this.shamanBlessCounter = 0f;
            }
            if (entityType.ShamanBlessingDuration <= 0)
            {
                entityType.IsShamanBlessing = false;
                this.shamanBlessCounter = 0f;
            }
        }

        if (entityType.IsCaught)
        {
            entityType.CaughtDuration -= Time.deltaTime;
            if (entityType.CaughtDuration <= 0)
            {
                entityType.IsCaught = false;
            }
        }

        if (entityType.IsPoisioning)
        {
            this.poisionCounter += Time.deltaTime;
            if (this.poisionCounter >= 1f)
            {
                Damage poisionDamage = new Damage();
                poisionDamage.DamageValue = entityType.PoisionDps;
                poisionDamage.ShowCrit = true;
                entityType.TakeDamage(poisionDamage);
                this.poisionCounter = 0f;
            }
        }

        if (entityType.IsBurningOilAttacked)
        {
            this.burningOilCounter += Time.deltaTime;
            if (this.burningOilCounter >= 1f)
            {
                Damage burningOilDamage = new Damage();
                burningOilDamage.DamageValue = entityType.BurningOilDps;
                burningOilDamage.ShowCrit = true;
                entityType.TakeDamage(burningOilDamage);
                this.burningOilCounter = 0f;
            }
            entityType.BurningOilDuration -= Time.deltaTime;
            if (entityType.BurningOilDuration <= 0)
            {
                entityType.IsBurningOilAttacked = false;
                this.burningOilCounter = 0f;
            }
        }

        if (this.releaseCounterDictionary != null && this.activeSpellDictionary != null)
        {
            //foreach (KeyValuePair<ActorSpellName, float> kv in this.releaseCounterDictionary)
            ActorSpellName[] actorSpellArray = new ActorSpellName[this.releaseCounterDictionary.Keys.Count];
            float[] counterArray = new float[this.releaseCounterDictionary.Keys.Count];
            this.releaseCounterDictionary.Keys.CopyTo(actorSpellArray, 0);
            this.releaseCounterDictionary.Values.CopyTo(counterArray, 0);
            for (int i = 0; i < counterArray.Length; i ++)
            {
                float temp = counterArray[i] + Time.deltaTime;
                ActorSpell spell = this.activeSpellDictionary[actorSpellArray[i]];
                if (temp >= spell.ReleaseInterval)
                {
                    this.ReleaseActiveSpell(entityType, spell);
                    temp = 0f;
                }
                this.releaseCounterDictionary[actorSpellArray[i]] = temp;
            }
        }
    }

    public override void Exit(ActorController entityType)
    {
    }

    public override bool OnMessage(ActorController entityType, Telegram telegram)
    {
        if (telegram.Msg == FSMessageType.FSMessageAttack)
        {
            if (telegram.Parameters.ContainsKey("Damage"))
            {
                entityType.TakeDamage((Damage)telegram.Parameters["Damage"], telegram.Sender);
                return true;
            }
        }
        return false;
    }

    public void ReleaseActiveSpell(ActorController entityType, ActorSpell actorSpell)
    {
        switch (actorSpell.ActorSpellName)
        {
            case ActorSpellName.MortarAttack:
                {
                    List<GameObject> enemies = entityType.SeekAndGetEnemiesInDistance(120);
                    if (enemies != null && enemies.Count != 0)
                    {
                        Damage motarAttackDamage = new Damage();
                        motarAttackDamage.DamageValue = 21;
                        motarAttackDamage.ShowCrit = true;
                        enemies.ForEach(
                            enemy =>
                                {
                                    GameObject maEffect =
                                        (GameObject)Object.Instantiate(Resources.Load("GameScene/ActorSkillEffect"));
									maEffect.transform.parent = enemy.transform;
									maEffect.transform.localPosition = new Vector3(0, 0, 0);
                                    tk2dSpriteAnimator animator = maEffect.GetComponent<tk2dSpriteAnimator>();
                                    animator.Play("Bombard");
                                    animator.AnimationCompleted = delegate
                                    {
                                        if (enemy != null)
                                        {
                                            ActorController actorCtrl = enemy.GetComponent<ActorController>();
                                            entityType.SendDamage(actorCtrl, motarAttackDamage);
                                            Object.Destroy(maEffect);
                                        }
                                    };
                                });
                    }
                    break;
                }
            case ActorSpellName.ArcaneExplosion:
                {
                    List<GameObject> enemies = entityType.SeekAndGetEnemiesInDistance(120);
                    if (enemies != null && enemies.Count != 0)
                    {
                        Damage motarAttackDamage = new Damage();
                        motarAttackDamage.DamageValue = 27;
                        motarAttackDamage.ShowCrit = true;
                        enemies.ForEach(
                            enemy =>
                                {
                                    GameObject aeEffect =
                                        (GameObject)Object.Instantiate(Resources.Load("GameScene/ActorSkillEffect"));
									aeEffect.transform.parent = enemy.transform;
									aeEffect.transform.localPosition = new Vector3(0, 0, 0);
                                    tk2dSpriteAnimator animator = aeEffect.GetComponent<tk2dSpriteAnimator>();
                                    animator.Play("ArcaneExplosion");
                                    animator.AnimationCompleted = delegate
                                        {
											if(enemy != null)
											{
                                            	ActorController actorCtrl = enemy.GetComponent<ActorController>();
                                            	entityType.SendDamage(actorCtrl, motarAttackDamage);
                                            	Object.Destroy(aeEffect);
											}
                                        };
                                });
                    }
                    break;
                }
            case ActorSpellName.HolyLight:
                {
                    List<GameObject> myActors =
                        ActorsManager.GetInstance().GetActorsOfFaction(entityType.MyActor.FactionType);
                    if (myActors != null && myActors.Count != 0)
                    {
                        GameObject targetActor = myActors[Random.Range(0, myActors.Count)];
                        Damage zapDamage = new Damage();
                        zapDamage.DamageValue = -300;
                        zapDamage.ShowCrit = true;
                        GameObject hlEffect =
                                        (GameObject)Object.Instantiate(Resources.Load("GameScene/ActorSkillEffect"));
						hlEffect.transform.parent = targetActor.transform;
						hlEffect.transform.localPosition = new Vector3(11, 38, 0);
                        tk2dSpriteAnimator animator = hlEffect.GetComponent<tk2dSpriteAnimator>();
                        animator.Play("HolyLight");
                        animator.AnimationCompleted = delegate
                        {
                            if (targetActor != null)
                            {
                                ActorController actorCtrl = targetActor.GetComponent<ActorController>();
                                entityType.SendDamage(targetActor.GetComponent<ActorController>(), zapDamage);
                                Object.Destroy(hlEffect);
                            }
                        };
                    }
                    break;
                }
            case ActorSpellName.ShamanBless:
                {
                    List<GameObject> myActors =
                        ActorsManager.GetInstance().GetActorsOfFaction(entityType.MyActor.FactionType);
                    if (myActors != null && myActors.Count != 0)
                    {
                        GameObject targetActor = myActors[Random.Range(0, myActors.Count)];
                        ActorController actorCtrl = targetActor.GetComponent<ActorController>();
                        actorCtrl.IsShamanBlessing = true;
                    }
                    break;
                }
            case ActorSpellName.Ensnare:
                {
                    List<GameObject> airForceActors =
                        ActorsManager.GetInstance().GetEnemyAirForceActorsOfFactionInDistance(entityType, 70);
                    if (airForceActors != null && airForceActors.Count != 0)
                    {
                        GameObject targetActor = airForceActors[Random.Range(0, airForceActors.Count)];
                        ActorController actorCtrl = targetActor.GetComponent<ActorController>();
                        GameObject ensnareEffectA =
                            (GameObject)Object.Instantiate(Resources.Load("GameScene/ActorSkillEffect"));
                        ensnareEffectA.transform.localPosition = entityType.myTransform.position;
                        float scale = Vector3.Distance(entityType.myTransform.position, targetActor.transform.position)
                                      / 60f;
                        ensnareEffectA.transform.localScale = new Vector3(scale, 1f, 1f);
                        tk2dSpriteAnimator animator = ensnareEffectA.GetComponent<tk2dSpriteAnimator>();
                        animator.Play("EnsnareA");
                        animator.AnimationCompleted = delegate
                            {
                                Object.Destroy(ensnareEffectA.gameObject);
                            };
                        actorCtrl.IsCaught = true;
                    }
                    break;
                }
            case ActorSpellName.GodBless:
                {
                    List<GameObject> myActors =
                        ActorsManager.GetInstance()
                            .GetFriendlyActorsInDistance(
                                entityType.MyActor.FactionType,
                                entityType.myTransform.position,
                                actorSpell.AttackRange);
                    if (myActors != null && myActors.Count != 0)
                    {
                        myActors.ForEach(
                            actor =>
                                {
                                    ActorController actorCtrl = actor.GetComponent<ActorController>();
                                    actorCtrl.MyActor.ActorArmor.ArmorAmount += actorSpell.IncreaseFriendlyForcesArmor;
                                });
                    }
                    break;
                }
        }
    }

    #endregion
}

public class Actor_StateWalk : State<ActorController>
{
    //private static Actor_StateWalk instance;

    #region Fields

    private float seekEnemyCounter;

    private float seekEnemyInterval = 0.5f;

    #endregion

    #region Public Methods and Operators

    public static Actor_StateWalk Instance()
    {
        return new Actor_StateWalk();
    }

    public override void Enter(ActorController entityType)
    {
        StringBuilder animName = new StringBuilder(entityType.MyActor.RaceType + "_");
        animName.Append(entityType.MyActor.ActorType);
        animName.Append("_Walk_");
        animName.Append(entityType.MyActor.FactionType);
        entityType.SelfAnimator.Play(animName.ToString());

        this.ResetRotation(entityType);
    }

    public override void Execute(ActorController entityType)
    {
        if (entityType.IsStun || entityType.IsCaught)
        {
            return;
        }
        Vector3 moveDistance = entityType.moveSpeed * Time.deltaTime
                               * (entityType.ActorPath.CurrentNode() - entityType.myTransform.position).normalized;
        entityType.myTransform.Translate(moveDistance, Space.World);
        if (entityType.ActorPath.CurrentIndex == entityType.ActorPath.NodesCount() - 1)
        {
            if (Vector3.Distance(entityType.ActorPath.CurrentNode(), entityType.myTransform.position)
                <= entityType.MyActor.ActorAttack.AttackRange)
            {
				if(entityType.TargetBuilding != null)
				{
					entityType.TargetEnemy = entityType.TargetBuilding.GetComponent<BuildingController>();
                	entityType.GetFSM().ChangeState(Actor_StateFight.Instance());
				}
                return;
            }
        }
        if ((entityType.ActorPath.CurrentNode() - entityType.myTransform.position).sqrMagnitude <= 0.5)
        {
            if (entityType.ActorPath.HasNext())
            {
                entityType.ActorPath.NextNode();
                this.ResetRotation(entityType);
            }
        }

        this.seekEnemyCounter += Time.deltaTime;
        if (this.seekEnemyCounter >= this.seekEnemyInterval)
        {
            if (entityType.SeekAndGetEnemies(false).Count != 0 || entityType.SeekAndGetEnemyBuildings().Count != 0)
            {
                entityType.GetFSM().ChangeState(Actor_StateBeforeFight.Instance());
            }
            else
            {
                List<GameObject> enemies =
                    entityType.SeekAndGetEnemiesInDistance(entityType.MyActor.ActorAttack.AttackRange, false);
                if (enemies.Count != 0)
                {
                    if (enemies[0] != null)
                    {
                        entityType.TargetEnemy = enemies[0].GetComponent<ActorController>();
                        entityType.GetFSM().ChangeState(Actor_StateFight.Instance());
                    }
                }
            }
            this.seekEnemyCounter = 0.0f;
        }
    }

    public override void Exit(ActorController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(ActorController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion

    #region Methods

    private void ResetRotation(ActorController entityType)
    {
        Quaternion newQuaternion = Quaternion.Euler(0, 0, 0);
		Transform hpBarTran = entityType.transform.FindChild("HpBar");
		Transform hpBarBkgTran = entityType.transform.FindChild("HpBarBkg");
        if (entityType.ActorPath.CurrentNode().x < entityType.myTransform.position.x)
        {
            newQuaternion.eulerAngles = new Vector3(0, 180, 0);
            entityType.gameObject.transform.rotation = newQuaternion;
			if(hpBarTran != null && hpBarBkgTran != null)
			{
				hpBarTran.localPosition = new Vector3(hpBarTran.localPosition.x, hpBarTran.localPosition.y, 0);
				hpBarBkgTran.localPosition = new Vector3(hpBarBkgTran.localPosition.x, hpBarBkgTran.localPosition.y, -1);
			}
        }
        else
        {
            newQuaternion.eulerAngles = new Vector3(0, 0, 0);
            entityType.gameObject.transform.rotation = newQuaternion;
			if(hpBarTran != null && hpBarBkgTran != null)
			{
				hpBarTran.localPosition = new Vector3(hpBarTran.localPosition.x, hpBarTran.localPosition.y, -1);
				hpBarBkgTran.localPosition = new Vector3(hpBarBkgTran.localPosition.x, hpBarBkgTran.localPosition.y, 0);
			}
        }
    }

    #endregion
}

public class Actor_StateBeforeFight : State<ActorController>
{
    #region Public Methods and Operators

    public static Actor_StateBeforeFight Instance()
    {
        return new Actor_StateBeforeFight();
    }

    public override void Enter(ActorController entityType)
    {
        StringBuilder animName = new StringBuilder(entityType.MyActor.RaceType + "_");
        animName.Append(entityType.MyActor.ActorType);
        animName.Append("_Walk_");
        animName.Append(entityType.MyActor.FactionType);
        entityType.SelfAnimator.Play(animName.ToString());

        List<GameObject> enemies = entityType.SeekAndGetEnemies();
        if (enemies == null || enemies.Count == 0)
        {
            enemies = entityType.SeekAndGetEnemyBuildings();
            if (enemies == null || enemies.Count == 0)
            {
                entityType.GetFSM().ChangeState(Actor_StateWalk.Instance());
            }
			else
			{
			    if (enemies[0] != null)
			    {
			        entityType.TargetEnemy = enemies[0].GetComponent<BuildingController>();
			    }
			}
        }
        else
        {
            if (enemies[0] != null)
            {
                entityType.TargetEnemy = enemies[0].GetComponent<ActorController>();
            }
        }
    }

    public override void Execute(ActorController entityType)
    {
        if (entityType.IsStun || entityType.IsCaught)
        {
            return;
        }

        if (entityType.TargetEnemy == null)
        {
            entityType.GetFSM().ChangeState(Actor_StateWalk.Instance());
            return;
        }

        Vector3 moveDistance = entityType.moveSpeed * Time.deltaTime
                               * (entityType.TargetEnemy.transform.position - entityType.myTransform.position)
                                     .normalized;
        entityType.myTransform.Translate(moveDistance, Space.World);

        if ((entityType.TargetEnemy.transform.position - entityType.myTransform.position).sqrMagnitude
            <= Mathf.Max(Mathf.Pow(entityType.MyActor.ActorAttack.AttackRange, 2), Mathf.Pow(30, 2)))
        {
            entityType.GetFSM().ChangeState(Actor_StateFight.Instance());
        }
    }

    public override void Exit(ActorController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(ActorController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class Actor_StateFight : State<ActorController>
{
    #region Fields

    private float attackSpeedCounter;

    private GameObject bloodBustVampire;

    #endregion

    #region Public Methods and Operators

    public static Actor_StateFight Instance()
    {
        return new Actor_StateFight();
    }

    public override void Enter(ActorController entityType)
    {
        this.attackSpeedCounter = 0.0f;
        if (entityType.TargetEnemy == null)
        {
            entityType.GetFSM().ChangeState(Actor_StateBeforeFight.Instance());
            return;
        }
        StringBuilder animName = new StringBuilder(entityType.MyActor.RaceType + "_");
        animName.Append(entityType.MyActor.ActorType);
        animName.Append("_Attack_");
        animName.Append(entityType.MyActor.FactionType);
        entityType.SelfAnimator.Play(animName.ToString());
        entityType.SelfAnimator.AnimationCompleted = delegate
            {
                entityType.SelfAnimator.SetFrame(0);
                entityType.SendDamage(
                    entityType.TargetEnemy,
                    entityType.CalculateCommonAttackDamage(entityType.TargetEnemy));
            };
        
    }

    public override void Execute(ActorController entityType)
    {
        if (entityType.IsStun || entityType.IsCaught)
        {
            return;
        }
        if (entityType.TargetEnemy == null)
        {
            entityType.GetFSM().ChangeState(Actor_StateBeforeFight.Instance());
            return;
        }

        this.attackSpeedCounter += Time.deltaTime;
        if (this.attackSpeedCounter >= entityType.AttackInterval)
        {
            entityType.SelfAnimator.Play();
            entityType.SelfAnimator.AnimationCompleted = delegate
                {
                    entityType.SelfAnimator.SetFrame(0);
                    entityType.SendDamage(
                        entityType.TargetEnemy,
                        entityType.CalculateCommonAttackDamage(entityType.TargetEnemy));
                };
            this.SendBulletToEnemy(entityType);
            this.PlayVampireAnimation(entityType);
            this.attackSpeedCounter = 0f;
        }
    }

    public override void Exit(ActorController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(ActorController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion

    #region Methods

    private void SendBulletToEnemy(ActorController entityType)
    {
        if (entityType.MyActor.ActorType == ActorType.Sniper || entityType.MyActor.ActorType == ActorType.Marksman)
        {
            entityType.SendBullet(entityType.TargetEnemy, BulletType.Line_White);
        }
        else if (entityType.MyActor.ActorType == ActorType.HeavyGunner || entityType.MyActor.ActorType == ActorType.MortarTeam)
        {
            entityType.SendBullet(entityType.TargetEnemy, BulletType.Shell);
        }
        else if (entityType.MyActor.ActorType == ActorType.GryphonRider || entityType.MyActor.ActorType == ActorType.SeniorGryphonRider)
        {
            entityType.SendBullet(entityType.TargetEnemy, BulletType.Magic_GryphonRider);
        }
        else if (entityType.MyActor.ActorType == ActorType.Pastor || entityType.MyActor.ActorType == ActorType.Sage)
        {
            entityType.SendBullet(entityType.TargetEnemy, BulletType.Magic_Pastor);
        }
        else if (entityType.MyActor.ActorType == ActorType.Warlock)
        {
            entityType.SendBullet(entityType.TargetEnemy, BulletType.Sphere_Warlock);
        }
        else if (entityType.MyActor.ActorType == ActorType.TrollBerserker
                 || entityType.MyActor.ActorType == ActorType.Kodo)
        {
            entityType.SendBullet(entityType.TargetEnemy, BulletType.Axe);
        }
        else if (entityType.MyActor.ActorType == ActorType.BatRider
                 || entityType.MyActor.ActorType == ActorType.SeniorBatRider
                 || entityType.MyActor.ActorType == ActorType.Catapult)
        {
            entityType.SendBullet(entityType.TargetEnemy, BulletType.SiegeStone);
        }
        else if (entityType.MyActor.ActorType == ActorType.Shaman
                 || entityType.MyActor.ActorType == ActorType.WitchDoctor)
        {
            entityType.SendBullet(entityType.TargetEnemy, BulletType.Sphere_Warlock);
        }
        else if (entityType.MyActor.ActorType == ActorType.TrollHunter)
        {
            entityType.SendBullet(entityType.TargetEnemy, BulletType.Javelin);
        }
        else if (entityType.MyActor.ActorType == ActorType.Wyvern || entityType.MyActor.ActorType == ActorType.WindRider)
        {
            entityType.SendBullet(entityType.TargetEnemy, BulletType.PoisonBullet);
        }
        this.PlayVampireAnimation(entityType);
    }

    private void PlayVampireAnimation(ActorController entityType)
    {
        if (entityType.BloodSuckingRatio > 0)
        {
            if (this.bloodBustVampire == null)
            {
                this.bloodBustVampire = (GameObject)Object.Instantiate(Resources.Load("GameScene/PlayerSkillBloodlust"));
            }
            this.bloodBustVampire.SetActive(true);
            this.bloodBustVampire.transform.parent = entityType.myTransform;
            tk2dSpriteAnimator vampireAnimator = this.bloodBustVampire.GetComponent<tk2dSpriteAnimator>();
            vampireAnimator.Play("Vampire");
            vampireAnimator.AnimationCompleted = delegate { this.bloodBustVampire.SetActive(false); };
        }
        else
        {
            Object.Destroy(this.bloodBustVampire);
        }
    }

    #endregion
}

public class Actor_StateBeforeDie : State<ActorController>
{
    //private static Actor_StateBeforeDie instance;

    #region Public Methods and Operators

    public static Actor_StateBeforeDie Instance()
    {
        //return instance ?? (instance = new Actor_StateBeforeDie());
        return new Actor_StateBeforeDie();
    }

    public override void Enter(ActorController entityType)
    {
        StringBuilder animName = new StringBuilder(entityType.MyActor.RaceType + "_");
        animName.Append(entityType.MyActor.ActorType);
        animName.Append("_Die_");
        animName.Append(entityType.MyActor.FactionType);
        entityType.SelfAnimator.Play(animName.ToString());
        entityType.SelfAnimator.AnimationCompleted =
            delegate { entityType.GetFSM().ChangeState(Actor_StateDie.Instance()); };
    }

    public override void Execute(ActorController entityType)
    {
    }

    public override void Exit(ActorController entityType)
    {
    }

    public override bool OnMessage(ActorController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}

public class Actor_StateDie : State<ActorController>
{
    //private static Actor_StateDie instance;

    #region Public Methods and Operators

    public static Actor_StateDie Instance()
    {
        //return instance ?? (instance = new Actor_StateDie());
        return new Actor_StateDie();
    }

    public override void Enter(ActorController entityType)
    {
        GameController gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();
        if (gameCtrl != null)
        {
            if (gameCtrl.GameType == GameType.PVE)
            {
                if (entityType.MyActor.FactionType != gameCtrl.MyFactionType)
                {
                    GameSceneController gameSceneCtrl =
                        GameObject.Find("GameSceneController").GetComponent<GameSceneController>();
                    if (gameSceneCtrl != null)
                    {
                        switch (entityType.MyActor.ActorLevel)
                        {
                            case ActorLevel.Normal:
                                gameSceneCtrl.CoinCount += 5;
                                break;
                            case ActorLevel.Senior:
                                gameSceneCtrl.CoinCount += 10;
                                break;
                            case ActorLevel.Hero:
                                gameSceneCtrl.CoinCount += 50;
                                break;
                        }
                    }
                }
            }
            else
            {
                if (entityType.MyActor.FactionType != gameCtrl.MyFactionType)
                {
                    GameSceneController gameSceneCtrl =
                        GameObject.Find("GameSceneController").GetComponent<GameSceneController>();
                    if (gameSceneCtrl != null)
                    {
                        switch (entityType.MyActor.ActorLevel)
                        {
                            case ActorLevel.Normal:
                                gameSceneCtrl.CoinCount += 5;
                                break;
                            case ActorLevel.Senior:
                                gameSceneCtrl.CoinCount += 10;
                                break;
                            case ActorLevel.Hero:
                                gameSceneCtrl.CoinCount += 50;
                                break;
                        }
                    }
                }
            }
        }
        entityType.DestroySelf();
    }

    public override void Execute(ActorController entityType)
    {
        base.Execute(entityType);
    }

    public override void Exit(ActorController entityType)
    {
        base.Exit(entityType);
    }

    public override bool OnMessage(ActorController entityType, Telegram telegram)
    {
        return base.OnMessage(entityType, telegram);
    }

    #endregion
}