using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class TowerScript : MonoBehaviour, IEffectApplier<EnemyScript>, IEffectReceiver<TowerScript>
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

    protected float _reloadProgress = 1f; // 1 = gotowy do strzału
    protected List<EnemyScript> targetsInRange = new List<EnemyScript>();

    [Header("Effects Settings")]
    public List<Effect<EnemyScript>> effectsToApply = new List<Effect<EnemyScript>>();

    private List<EffectInstance<TowerScript>> _activeEffects = new List<EffectInstance<TowerScript>>();

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
        TickEffects();

        _reloadProgress += Time.deltaTime / CalculateReloadTimeAfterDebuffs();
        _reloadProgress = Mathf.Clamp01(_reloadProgress);

        if (targetsInRange.Count > 0)
        {
            EnemyScript target = targetsInRange[0];
            RotateTowardsTarget(target);

            if (_reloadProgress >= 1f)
            {
                Shoot(target);
                _reloadProgress = 0f;
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
            projectile.Setup(target, damage, this);
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
    EnemyScript enemy = other.GetComponent<EnemyScript>();

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
    EnemyScript enemy = other.GetComponent<EnemyScript>();
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

    public void ApplyEffect(Effect<TowerScript> effect)
    {
        if (UnityEngine.Random.value > effect.applyChance)
        {
            return;
        }


        if (!effect.isStackable)
        {
            var existingEffect = _activeEffects.Find(e => e.Data == effect);
            if (existingEffect != null)
            {
                existingEffect.Refresh();
                return;
            }
        }

        var newInstance = new EffectInstance<TowerScript>(effect, this);
        _activeEffects.Add(newInstance);
    }

    public void RemoveEffect(Effect<TowerScript> effect)
    {
        
    }

    protected void TickEffects()
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

    protected List<TowerSlowEffect> getAllActiveSlowEffects()
    {
        return _activeEffects
            .Where(e => e.Data is TowerSlowEffect)
            .Select(e => (TowerSlowEffect)e.Data)
            .ToList();
    }


    protected float CalculateReloadTimeAfterDebuffs()
    {
        float calculatedReloadTime = reloadTime;

        var slowEffects = getAllActiveSlowEffects();

        foreach (var slowEffect in slowEffects)
        {
            calculatedReloadTime *= (1f + slowEffect.decreaseRatio);
        }

        return calculatedReloadTime;
    }


}