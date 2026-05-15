using System;
using System.Collections.Generic;
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

    public int CurrencyLoot => currencyLoot;
    public int DamageToBase => damageToBase;

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    protected virtual void Start()
    {
        setEnemyType();
        setupStats();
        animator = GetComponent<Animator>();
        animator.Play("move");
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
        Vector3 direction = _targetWaypoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
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

    public virtual void TakeDamage(float amount) 
    {
        health -= Mathf.RoundToInt(amount);

        if (health <= 0)
        {
            health = 0;
            Defeat();
        }
    }

    protected virtual void Defeat()
    {
        Debug.Log("Mob defeated");
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
    }

    protected virtual void OnEnemyGone()
    {
        OnEnemyGoneCallback?.Invoke(enemyType);
    }

    public void ApplyEffect(Effect<EnemyScript> effectData)
    {

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

    public virtual void DecreaseSpeed(float decreaseRatio)
    {
        if (decreaseRatio >= 0 && decreaseRatio <= 1)
        {
            speed -= speed*decreaseRatio;
        }
    }

    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
