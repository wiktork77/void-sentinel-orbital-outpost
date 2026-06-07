using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStunEffect", menuName = "Effects/Debuff/Stun")]
public class StunEffect : Effect<EnemyScript>
{
    public override Action<EnemyScript> OnApply(EnemyScript target)
    {
        target.Stun(magicSchool);

        return (enemy) => {
            enemy.Unstun();
        };
    }

    public override void OnRemove(EnemyScript target)
    {
    }

    public override void OnTick(EnemyScript target, float deltaTime)
    {
    }
}
