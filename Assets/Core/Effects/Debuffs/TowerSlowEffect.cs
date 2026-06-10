using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTowerSlowEffect", menuName = "Effects/TowerSlow")]
public class TowerSlowEffect : Effect<TowerScript>
{
    public float decreaseRatio;
    public override Action<TowerScript> OnApply(TowerScript target)
    {
        return (t) => { };
    }

    public override void OnRemove(TowerScript target)
    {
    }

    public override void OnTick(TowerScript target, float deltaTime)
    {
    }
}
