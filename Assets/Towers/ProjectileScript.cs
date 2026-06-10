using System;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private EnemyScript target;
    protected float damage;
    public float speed = 15f; 
    public float rotationOffset = -90f;

    public Action OnHit;

    public TowerScript owner;

    public void Setup(EnemyScript _target, float _damage, TowerScript owner)
    {
        target = _target;
        damage = _damage;
        
        this.owner = owner;
    }

    protected virtual void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); 
            return;
        }

        // Ruch w stronę drona
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        // Obracanie pocisku "nosem" do celu (opcjonalnie)
        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotationOffset);

        // Sprawdzanie trafienia
        if (Vector2.Distance(transform.position, target.transform.position) < 0.2f)
        {
            HitTarget();
        }
    }

    void HitTarget()
{
    if (target != null)
    {
        // Wywołujemy funkcję TakeDamage z EnemyScript
        target.TakeDamage(damage, owner);
        OnHit?.Invoke();
        
        // Opcjonalnie: Debug, żebyś widział w konsoli, że pocisk "uderzył"
        // Debug.Log($"Pocisk trafił {target.name} zadając {damage} DMG.");
    }
    
    // Niszczymy pocisk po trafieniu
    Destroy(gameObject);
}
}