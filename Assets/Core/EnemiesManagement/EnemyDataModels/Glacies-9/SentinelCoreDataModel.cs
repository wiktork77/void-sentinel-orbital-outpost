using UnityEngine;

public class SentinelCoreDataModel : EnemyDataModel
{
    public override string Name => "Sentinel Core";

    public override string Description => temporaryDescription;

    public override int MaxHealth => 1500;

    public override int Loot => 500;

    public override int DamageToBase => int.MaxValue;

    public override float Speed => 1.7f;
}
