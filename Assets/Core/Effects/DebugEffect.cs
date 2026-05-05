using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDebugEffect", menuName = "Effects/Debug")]
public class DebugEffect : Effect<EnemyScript>
{
    public override void OnApply(EnemyScript target)
    {
        Debug.Log($"Na³o¿ono {effectName} na {target.name}!");
    }

    public override void OnTick(EnemyScript target, float deltaTime)
    {
        Debug.Log($"{target.name} dostaje obra¿enia od Ticku!");
    }

    public override void OnRemove(EnemyScript target)
    {
        Debug.Log($"Efekt {effectName} wygas³ na {target.name}.");
    }
}
