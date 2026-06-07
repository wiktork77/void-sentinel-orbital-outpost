using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class TowerScript : MonoBehaviour, IEffectApplier<EnemyScript>
{
    protected TowerType towerType;

    protected int cost = 100;
    protected float range = 3f;
    protected float damage = 10f;
    protected float reloadTime = 1f; 

    [Header("References")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform partToRotate; // Przeciągnij tu grafikę lufy/działa
    public float rotationOffset = -90f; // Regulacja, jeśli lufa patrzy w złym kierunku

    protected float nextFireTime = 0f;
    protected List<EnemyScript> targetsInRange = new List<EnemyScript>();

    [Header("Effects Settings")]
    public List<Effect<EnemyScript>> effectsToApply = new List<Effect<EnemyScript>>();

    protected virtual void Start()
    {
        setTowerType();
        setupStats();
        
        // Dynamiczne ustawianie zasięgu collidera
        CircleCollider2D rangeCollider = GetComponent<CircleCollider2D>();
        if (rangeCollider != null)
        {
            rangeCollider.radius = range;
            rangeCollider.isTrigger = true;
        }
    }

    protected virtual void Update()
    {
        targetsInRange.RemoveAll(t => t == null);

        if (targetsInRange.Count > 0)
        {
            EnemyScript target = targetsInRange[0];
            
            // Obracamy tylko wyznaczoną część (np. lufę)
            RotateTowardsTarget(target);

            if (Time.time >= nextFireTime)
            {
                Shoot(target);
                nextFireTime = Time.time + reloadTime;
            }
        }
    }

    protected virtual void Shoot(EnemyScript target)
{
    if (projectilePrefab != null && firePoint != null)
    {
        // 1. Tworzymy pocisk
        GameObject projGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        
        // 2. Szukamy na nim skryptu ProjectileScript
        ProjectileScript projectile = projGO.GetComponent<ProjectileScript>();

        Action OnProjectileHit = () =>
        {
            foreach (var effect in effectsToApply)
            {
                SendEffect(effect, target);
            }
        };
        
        // 3. Przekazujemy mu cel (to jest to "pchnięcie", którego Ci brakuje!)
        if (projectile != null)
        {
            projectile.OnHit += OnProjectileHit;
            projectile.Setup(target, damage);
        }
    }
}

protected void RotateTowardsTarget(EnemyScript target)

{
    if (partToRotate == null) return;

    Vector2 direction = target.transform.position - partToRotate.position;
    
    // Ustawiamy "przód" lufy w stronę drona
    // Jeśli lufa patrzy bokiem, zmień na: partToRotate.right = direction;
    partToRotate.up = direction; 
    
    // Debug, żebyś widział linię celowania w oknie Scene
    // Debug.DrawLine(partToRotate.position, target.transform.position, Color.yellow);
}

    // Wyświetla zasięg wieży w oknie Scene (czerwony okrąg)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    // Szukamy skryptu na obiekcie, który wszedł w zasięg LUB na jego rodzicu
    EnemyScript enemy = other.GetComponentInParent<EnemyScript>();
    
    if (enemy != null)
    {
        if (!targetsInRange.Contains(enemy)) // Unikamy dublowania na liście
        {
            targetsInRange.Add(enemy);
            // Debug.Log("<color=green>Wykryto wroga:</color> " + enemy.name);
        }
    }
}

    private void OnTriggerExit2D(Collider2D other)
{
    EnemyScript enemy = other.GetComponentInParent<EnemyScript>();
    if (enemy != null)
    {
        targetsInRange.Remove(enemy);
        // Debug.Log("<color=red>Wróg wyszedł z zasięgu:</color> " + enemy.name);
    }
}

    protected abstract void setTowerType();
    protected virtual void setupStats()
    {
        TowerDataModel model =  TowerDataModelResolver.getTowerDataModel(towerType);

        cost = model.Cost;
        range = model.Range;
        damage  = model.Damage;
        reloadTime = model.ReloadTime;
    }

    public void SendEffect(Effect<EnemyScript> effect, EnemyScript receiver)
    {
        if (effect != null && receiver != null)
        {
            receiver.ApplyEffect(effect);
        }
    }
}