using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBurnEffect", menuName = "Effects/Burn")]
public class BurnEffect : Effect<EnemyScript>
{
    public float burnDamage;
    public override Action<EnemyScript> OnApply(EnemyScript target)
    {
        return (enemy) => {};
    }

    public override void OnRemove(EnemyScript target)
    {

    }

    public override void OnTick(EnemyScript target, float deltaTime)
    {
        target.TakeDamage(burnDamage);
    }
}
