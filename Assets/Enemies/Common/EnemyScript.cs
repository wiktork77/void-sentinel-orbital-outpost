using UnityEngine;
using System;

public abstract class EnemyScript : MonoBehaviour
{
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

    private Action<int> _onReachEndCallback;
    private Action<int> _onDefeatedCallback;

    protected virtual void Start()
    {
        setEnemySpecificValues();
        animator = GetComponent<Animator>();
        animator.Play("move");
    }

    protected virtual void Update()
    {
        // Jeœli nie mamy celu, nie robimy nic
        if (_targetWaypoint == null) return;

        Move();
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

        // Sprawdzamy, czy to koniec œcie¿ki
        if (_currentWaypointIndex < path.Length)
        {
            _targetWaypoint = path[_currentWaypointIndex];
        }
        else
        {
            // Przeciwnik dotar³ do koñca (np. bazy gracza)
            ReachEnd();
        }
    }

    public void SetOnReachEndCallback(Action<int> callback)
    {
        _onReachEndCallback = callback;
    }

    public void SetOnDefeatedCallback(Action<int> callback)
    {
        _onDefeatedCallback = callback;
    }

    protected virtual void ReachEnd()
    {
        _onReachEndCallback?.Invoke(damageToBase);
        Destroy(gameObject);
    }

    protected virtual void Defeat()
    {
        _onDefeatedCallback?.Invoke(currencyLoot);
    }

    protected virtual void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            // FOR LATER POSSIBLE UI UPDATE
            health = 0;

            Defeat();
        }
    }

    protected abstract void setEnemySpecificValues();
}
