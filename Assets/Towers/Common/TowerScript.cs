using UnityEngine;
using System.Collections.Generic;

public abstract class TowerScript : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] protected int cost = 100;
    [SerializeField] protected float range = 3f;
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float reloadTime = 1f;

    [Header("References")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform partToRotate; // Przeciągnij tu grafikę lufy/działa
    public float rotationOffset = -90f; // Regulacja, jeśli lufa patrzy w złym kierunku

    protected float nextFireTime = 0f;
    protected List<EnemyScript> targetsInRange = new List<EnemyScript>();

    protected virtual void Start()
    {
        setTowerSpecificValues();
        
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
        
        // 3. Przekazujemy mu cel (to jest to "pchnięcie", którego Ci brakuje!)
        if (projectile != null)
        {
            projectile.Setup(target, damage);
        }
    }
}

private void RotateTowardsTarget(EnemyScript target)

{
    Debug.Log("Obracamy w stronę: " + target.name);
    // Debug.Log("Pozycja wieży: " + partToRotate.position);
    Debug.Log("Pozycja celu: " + partToRotate);
    if (partToRotate == null) return;
    Debug.Log("Pozycja celu: " + target.transform.position);

    Vector2 direction = target.transform.position - partToRotate.position;
    
    // Ustawiamy "przód" lufy w stronę drona
    // Jeśli lufa patrzy bokiem, zmień na: partToRotate.right = direction;
    partToRotate.up = direction; 
    
    // Debug, żebyś widział linię celowania w oknie Scene
    Debug.DrawLine(partToRotate.position, target.transform.position, Color.yellow);
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
            Debug.Log("<color=green>Wykryto wroga:</color> " + enemy.name);
        }
    }
}

    private void OnTriggerExit2D(Collider2D other)
{
    EnemyScript enemy = other.GetComponentInParent<EnemyScript>();
    if (enemy != null)
    {
        targetsInRange.Remove(enemy);
        Debug.Log("<color=red>Wróg wyszedł z zasięgu:</color> " + enemy.name);
    }
}

    protected abstract void setTowerSpecificValues();
}