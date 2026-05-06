using UnityEngine;

[CreateAssetMenu(fileName = "NewBurnEffect", menuName = "Effects/Burn")]
public class BurnEffect: Effect<EnemyScript>
{
    public float damagePerTick;

    public override void OnTick(EnemyScript target, float deltaTime)
    {
        target.TakeDamage(damagePerTick);
    }

    public override void OnApply(EnemyScript target)
    {
   
    }

    public override void OnRemove(EnemyScript target)
    {
  
    }
    
}
