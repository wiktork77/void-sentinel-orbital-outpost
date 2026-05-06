using UnityEngine;

public class SlowAuraTower : TowerScript
{
    [Header("Aura Settings")]
    public Transform rangeVisual; // Tu przeciągniesz obiekt "RangeVisual"

    protected override void setTowerSpecificValues()
    {
        // Twoje statystyki
        cost = 150;
        range = 10f; 
        reloadTime = 0.5f; // Jak często wieża "odświeża" spowolnienie u wrogów

        // Automatyczne skalowanie okręgu do zasięgu
        if (rangeVisual != null)
        {
            float diameter = range * 2f;
            rangeVisual.localScale = new Vector3(diameter, diameter, 1f);
        }
    }

    protected override void Update()
    {
        // 1. Czyścimy listę z martwych wrogów (metoda z klasy bazowej)
        targetsInRange.RemoveAll(t => t == null);

        // 2. Co sekundę (reloadTime) nakładamy efekt na wszystkich w zasięgu
        if (Time.time >= nextFireTime)
        {
            ApplySlowToAll();
            nextFireTime = Time.time + reloadTime;
        }
    }

    private void ApplySlowToAll()
    {
        foreach (EnemyScript enemy in targetsInRange)
        {
            foreach (var effect in effectsToApply)
            {
                SendEffect(effect, enemy);
            }
        }
    }

    // Blokujemy strzelanie pociskami, bo to wieża obszarowa
    protected override void Shoot(EnemyScript target) { }
}