using UnityEngine;
using System;

public class TripleTowerScript : TowerScript
{
    [Header("Triple Shot Settings")]
    [Range(5f, 30f)]
    public float spreadAngle = 20f;

    // Przechowujemy aktualnie namierzonego losowego wroga
    private EnemyScript currentRandomTarget;

    protected override void setupStats()
    {
        base.setupStats();
    }

    protected override void setTowerType()
    {
        towerType = TowerType.TRIPLE_TOWER;
    }

    // Nadpisujemy Update, aby zmienić logikę wybierania celu
    protected override void Update()
    {
        // 1. Czyścimy listę z martwych wrogów (tak jak w bazie)
        targetsInRange.RemoveAll(t => t == null);

        if (targetsInRange.Count > 0)
        {
            // 2. Jeśli nie mamy celu LUB nasz poprzedni cel zginął/wyszedł z zasięgu, losujemy nowego
            if (currentRandomTarget == null || !targetsInRange.Contains(currentRandomTarget))
            {
                int randomIndex = UnityEngine.Random.Range(0, targetsInRange.Count);
                currentRandomTarget = targetsInRange[randomIndex];
            }

            // 3. Obracamy lufę w stronę wylosowanego wroga
            RotateTowardsTarget(currentRandomTarget);

            // 4. Strzelamy, jeśli minął czas przeładowania
            if (Time.time >= nextFireTime)
            {
                Shoot(currentRandomTarget);
                nextFireTime = Time.time + reloadTime;

                // OPCJONALNIE: Odkomentuj linijkę niżej, jeśli chcesz, żeby wieża 
                // PO KAŻDYM STRZALE losowała nowego wroga (całkowity chaos i rozrzut!)
                // currentRandomTarget = null; 
            }
        }
        else
        {
            currentRandomTarget = null;
        }
    }

    // Metoda Shoot pozostaje bez zmian
    protected override void Shoot(EnemyScript target)
    {
        if (projectilePrefab == null || firePoint == null) return;

        // Środkowy
        SpawnProjectile(target, firePoint.rotation);

        // Lewy
        Quaternion leftRotation = firePoint.rotation * Quaternion.Euler(0, 0, spreadAngle);
        SpawnProjectile(target, leftRotation);

        // Prawy
        Quaternion rightRotation = firePoint.rotation * Quaternion.Euler(0, 0, -spreadAngle);
        SpawnProjectile(target, rightRotation);
    }

    private void SpawnProjectile(EnemyScript target, Quaternion rotation)
    {
        GameObject projGO = Instantiate(projectilePrefab, firePoint.position, rotation);
        SpreadProjectileScript projectile = projGO.GetComponent<SpreadProjectileScript>();

        Action OnProjectileHit = () =>
        {
            foreach (var effect in effectsToApply)
            {
                SendEffect(effect, target);
            }
        };

        if (projectile != null)
        {
            projectile.OnHit += OnProjectileHit;
            projectile.Setup(target, damage); 
        }
    }
}