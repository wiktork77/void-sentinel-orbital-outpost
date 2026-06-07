using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSlowEffect", menuName = "Effects/Slow")]
public class SlowEffect : Effect<EnemyScript>
{
    public float decreaseRatio;

    public override Action<EnemyScript> OnApply(EnemyScript target)
    {
        float decreasedAmount = target.Slow(decreaseRatio, magicSchool);

        return (enemy) => {
            float currentSpeed = enemy.Speed;
            float desiredSpeed = currentSpeed + decreasedAmount;

            enemy.SetSpeed(desiredSpeed);
        };
    }

    public override void OnRemove(EnemyScript target)
    {
    }

    public override void OnTick(EnemyScript target, float deltaTime)
    {
        // nothing - not periodic, but can be, for example the slow effect can dampen over time
    }
}
