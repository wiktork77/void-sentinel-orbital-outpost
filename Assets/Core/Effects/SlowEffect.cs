using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSlowEffect", menuName = "Effects/Slow")]
public class SlowEffect : Effect<EnemyScript>
{
    private Dictionary<EnemyScript, float> amountDecreased = new();
    public float decreaseRatio;

    public override void OnApply(EnemyScript target)
    {
        float decreasedAmount = target.Slow(decreaseRatio);
        amountDecreased.Add(target, decreasedAmount);
    }

    public override void OnRemove(EnemyScript target)
    {
        RevertSlowEffect(target);
        amountDecreased.Remove(target);
    }

    public override void OnTick(EnemyScript target, float deltaTime)
    {
        // nothing - not periodic, but can be, for example the slow effect can dampen over time
    }

    private void RevertSlowEffect(EnemyScript target)
    {
        float decreasedAmount = amountDecreased[target];
        float currentSpeed = target.Speed;

        float desiredSpeed = currentSpeed + decreasedAmount;

        target.SetSpeed(desiredSpeed);


        Debug.Log("Reverting speed of " + target.name + " to  " + desiredSpeed);
    }
}
