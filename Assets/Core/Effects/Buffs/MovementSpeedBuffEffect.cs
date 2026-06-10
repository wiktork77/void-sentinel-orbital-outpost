using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementSpeedBuff", menuName = "Effects/Buffs/MovementSpeed")]
public class MovementSpeedBuffEffect : Effect<EnemyScript>
{
    public float increaseValue;

    public override Action<EnemyScript> OnApply(EnemyScript target)
    {
        //float increasedAmount = target.BuffSpeed(increaseValue);

        return (enemy) =>
        {
            //float currentSpeed = enemy.Speed;
            //float desiredSpeed = currentSpeed - increaseValue;

            //enemy.SetSpeed(desiredSpeed);
        };
    }

    public override void OnRemove(EnemyScript target)
    {
    }

    public override void OnTick(EnemyScript target, float deltaTime)
    {
        // nothing - not periodic, but can be, for example the speed effect can dampen over time
    }


    private void RevertSpeedEffect(EnemyScript target)
    {
        // Debug.Log("Reverting speed of " + target.name + " to  " + desiredSpeed);
    }
}
