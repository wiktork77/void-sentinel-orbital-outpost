using UnityEngine;

public class IceCrawlerDataModel : EnemyDataModel
{
    public override string Name => "Ice Crawler";

    public override string Description => temporaryDescription;

    public override int MaxHealth => 350;

    public override int Loot => 25;

    public override int DamageToBase => 10;

    public override float Speed => 1f;
}
