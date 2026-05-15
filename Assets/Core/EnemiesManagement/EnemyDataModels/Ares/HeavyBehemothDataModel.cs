using UnityEngine;

public class HeavyBehemothDataModel : EnemyDataModel
{
    public override string Name => "Heavy Behemoth";

    public override string Description => temporaryDescription;

    public override int MaxHealth => 300;

    public override int Loot => 15;

    public override int DamageToBase => 10;

    public override float Speed => 1.2f;
}
