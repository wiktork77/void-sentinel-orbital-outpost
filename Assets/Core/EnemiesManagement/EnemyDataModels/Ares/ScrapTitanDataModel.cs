using UnityEngine;

public class ScrapTitanDataModel : EnemyDataModel
{
    public override string Name => "Scrap Titan";

    public override string Description => temporaryDescription;

    public override int MaxHealth => 1000;

    public override int Loot => 100;

    public override int DamageToBase => int.MaxValue;

    public override float Speed => 1f;
}
