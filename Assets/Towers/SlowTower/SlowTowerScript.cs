using UnityEngine;

public class SlowAuraTower : TowerScript
{
    [Header("Aura Settings")]
    public Transform rangeVisual; // Tu przeciągniesz obiekt "RangeVisual"

    protected override void setupStats()
    {
        base.setupStats();

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

        _reloadProgress += Time.deltaTime / CalculateReloadTimeAfterDebuffs();
        _reloadProgress = Mathf.Clamp01(_reloadProgress);

        // 2. Co sekundę (reloadTime) nakładamy efekt na wszystkich w zasięgu

        if (_reloadProgress >= 1f)
        {
            ApplySlowToAll();
            _reloadProgress = 0f;
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

    protected override void setTowerType()
    {
        towerType = TowerType.SLOW_TOWER;
    }
}