using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour, IEffectReceiver<EnemyScript>
{
    protected EnemyType enemyType;

    protected float speed = 2f;
    protected int maxHealth = 67;
    protected int health = 67;

    protected int maxBarrier = 0;
    protected int barrier = 0;

    protected int currencyLoot = 1;
    protected int damageToBase = 1;

    protected Animator animator;
    protected Transform[] path;

    private int _currentWaypointIndex = 0;
    private Transform _targetWaypoint;


    public Action<EnemyScript> _OnEnemyDefeated;
    public Action<EnemyScript> _OnEnemyReachEnd;

    public Action<EnemyType> OnEnemyGoneCallback;

    private List<EffectInstance<EnemyScript>> _activeEffects = new List<EffectInstance<EnemyScript>>();

    private Boolean CanMove = true;

    public int CurrencyLoot => currencyLoot;
    public int DamageToBase => damageToBase;

    public int Health => health;
    public float Speed
    {
        get => speed;
    }

    protected virtual void Start()
    {
        setEnemyType();
        setupStats();
        animator = GetComponent<Animator>();
        SetAnimation("move");
    }

    protected virtual void Update()
    {
        // Je�li nie mamy celu, nie robimy nic
        if (_targetWaypoint == null) return;

        Move();
        TickEffects();
        CheckDistance();
    }

    public void setupRoute(Transform[] route)
    {
        path = route;
        if (path != null && path.Length > 0)
        {
            _currentWaypointIndex = 0;
            _targetWaypoint = path[_currentWaypointIndex];
        }
    }

    private void Move()
    {
        if (CanMove)
        {
            Vector3 direction = _targetWaypoint.position - transform.position;
            transform.Translate(direction.normalized * CalculateCurrentSpeed() * Time.deltaTime, Space.World);
        }
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, _targetWaypoint.position) < 0.1f)
        {
            SetNextWaypoint();
        }
    }

    private void SetNextWaypoint()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex < path.Length)
        {
            _targetWaypoint = path[_currentWaypointIndex];
        }
        else
        {
            ReachEnd();
        }
    }

    protected virtual void ReachEnd()
    {
        _OnEnemyReachEnd?.Invoke(this);


        OnEnemyGone();
        Destroy(gameObject);
    }

    public virtual void TakeDamage(float amount, object source) 
    {
        health -= Mathf.RoundToInt(amount);

        if (health <= 0)
        {
            health = 0;
            Defeat();
        }

        Debug.Log("taking " + amount + " damage");
    }

    public virtual void Heal(float amount)
    {
        health = Mathf.Min(health + Mathf.RoundToInt(amount), maxHealth);

        Debug.Log("Healing... current health: " + health);
    }

    protected virtual void Defeat()
    {
        _OnEnemyDefeated?.Invoke(this);

        
        OnEnemyGone();
        Destroy(gameObject);
    }

    protected abstract void setEnemyType();

    protected virtual void setupStats()
    {
        EnemyDataModel dataModel = EnemyDataModelResolver.getEnemyDataModel(enemyType);

        maxHealth = dataModel.MaxHealth;
        health = dataModel.MaxHealth;
        damageToBase = dataModel.DamageToBase;
        speed = dataModel.Speed;
        currencyLoot = dataModel.Loot;
    }

    protected virtual void OnEnemyGone()
    {
        OnEnemyGoneCallback?.Invoke(enemyType);
    }

    public void ApplyEffect(Effect<EnemyScript> effectData)
    {
        if (UnityEngine.Random.value > effectData.applyChance)
        {
            return;
        }


        if (!effectData.isStackable)
        {
            var existingEffect = _activeEffects.Find(e => e.Data == effectData);
            if (existingEffect != null)
            {
                existingEffect.Refresh();
                return;
            }
        }

        var newInstance = new EffectInstance<EnemyScript>(effectData, this);
        _activeEffects.Add(newInstance);
    }

    public void RemoveEffect(Effect<EnemyScript> effect)
    {
        Debug.Log("Effect Removed - Enemy");
    }

    private void TickEffects()
    {
        for (int i = _activeEffects.Count - 1; i >= 0; i--)
        {
            var effect = _activeEffects[i];

            effect.Update(Time.deltaTime);

            if (effect.IsFinished)
            {
                effect.End(); 
                _activeEffects.RemoveAt(i);
            }
        }
    }

    //public virtual float Slow(float decreaseRatio, EffectMagicSchool magicSchool)
    //{
    //    float decreasedAmount = 0;

    //    if (decreaseRatio >= 0 && decreaseRatio <= 1)
    //    {
    //        decreasedAmount = speed * decreaseRatio;
    //        speed -= decreasedAmount;
    //    }

    //    return decreasedAmount;
    //}

    public virtual void Stun(EffectMagicSchool magicSchool)
    {
        SetAnimation("idle");
        CanMove = false;
    }

    public virtual void Unstun()
    {
        SetAnimation("move");
        CanMove = true;
    }

    //public virtual float BuffSpeed(float increaseAmount)
    //{
    //    if (increaseAmount >= 0)
    //    {
    //        speed += increaseAmount;
    //        return increaseAmount;
    //    } else
    //    {
    //        return 0;
    //    }
    //}

    //public virtual void SetSpeed(float speed)
    //{
    //    this.speed = speed;
    //}

    public virtual void SetAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    protected List<SlowEffect> getAllActiveSlowEffects()
    {
        return _activeEffects
            .Where(e => e.Data is SlowEffect)
            .Select(e => (SlowEffect)e.Data)
            .ToList();
    }

    protected List<MovementSpeedBuffEffect> getAllActiveMovementSpeedBuffEffects()
    {
        return _activeEffects
            .Where(e => e.Data is MovementSpeedBuffEffect)
            .Select(e => (MovementSpeedBuffEffect)e.Data)
            .ToList();
    }


    protected virtual float CalculateSpeedAfterBuffs()
    {
        float speedAfterEffects = speed;

        var speedEffects = getAllActiveMovementSpeedBuffEffects();

        foreach (var effect in speedEffects)
        {
            speedAfterEffects += effect.increaseValue;
        }

        return speedAfterEffects;
    }



    protected virtual float CalculateSpeedAfterDebuffs(float currentSpeed)
    {
        float speedAfterEffects = currentSpeed;

        var slowEffects = getAllActiveSlowEffects();

        foreach (var effect in slowEffects)
        {
            speedAfterEffects -= (speedAfterEffects * effect.decreaseRatio);
        }

        return speedAfterEffects;
    }

    protected virtual float CalculateCurrentSpeed()
    {
        float speedAfterBuffs = CalculateSpeedAfterBuffs();
        float speedAfterEffects = CalculateSpeedAfterDebuffs(speedAfterBuffs);

        return speedAfterEffects;
    }
}
