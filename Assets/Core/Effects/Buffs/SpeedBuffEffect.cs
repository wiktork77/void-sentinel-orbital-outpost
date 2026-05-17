using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSlowEffect", menuName = "Effects/Buffs/Speed")]
public class SpeedBuffEffect : Effect<EnemyScript>
{
    private Dictionary<EnemyScript, float> affected = new();

    public float increaseValue;

    public override void OnApply(EnemyScript target)
    {
        float increasedAmount = target.BuffSpeed(increaseValue);
        affected.Add(target, increasedAmount);
    }

    public override void OnRemove(EnemyScript target)
    {
        throw new System.NotImplementedException();
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
