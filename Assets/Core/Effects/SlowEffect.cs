using UnityEngine;

[CreateAssetMenu(fileName = "NewSlowEffect", menuName = "Effects/Slow")]
public class SlowEffect : Effect<EnemyScript>
{
    public float decreaseRatio;
    private float originalSpeed;

    public override void OnApply(EnemyScript target)
    {
        originalSpeed = target.Speed;
        target.DecreaseSpeed(decreaseRatio);
    }

    public override void OnRemove(EnemyScript target)
    {
        target.Speed = originalSpeed;
    }

    public override void OnTick(EnemyScript target, float deltaTime)
    {
        // nothing - not periodic, but can be, for example the slow effect can dampen over time
    }
}
