using UnityEngine;
using System;

public class TripleTowerScript : TowerScript
{
    [Header("Triple Shot Settings")]
    [Range(5f, 30f)]
    public float spreadAngle = 15f; // Kąt rozrzutu bocznych pocisków (np. 15 stopni)

    protected override void setupStats()
    {
        base.setupStats();
    }

    protected override void setTowerType()
    {
        towerType = TowerType.TRIPLE_TOWER;
    }

    // Nadpisujemy oryginalne strzelanie z klasy bazowej
    protected override void Shoot(EnemyScript target)
    {
        if (projectilePrefab == null || firePoint == null) return;

        // 1. Środkowy pocisk (leci prosto tak jak w klasie bazowej)
        SpawnProjectile(target, firePoint.rotation);

        // 2. Lewy pocisk (obrócony o +spreadAngle)
        Quaternion leftRotation = firePoint.rotation * Quaternion.Euler(0, 0, spreadAngle);
        SpawnProjectile(target, leftRotation);

        // 3. Prawy pocisk (obrócony o -spreadAngle)
        Quaternion rightRotation = firePoint.rotation * Quaternion.Euler(0, 0, -spreadAngle);
        SpawnProjectile(target, rightRotation);
    }

    // Pomocnicza metoda do tworzenia pojedynczego pocisku (skopiowana z Twojego TowerScript)
    private void SpawnProjectile(EnemyScript target, Quaternion rotation)
    {
        GameObject projGO = Instantiate(projectilePrefab, firePoint.position, rotation);
        ProjectileScript projectile = projGO.GetComponent<ProjectileScript>();

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
            // Przekazujemy mu cel i obrażenia pobrane z modelu danych
            projectile.Setup(target, damage); 
        }
    }
}