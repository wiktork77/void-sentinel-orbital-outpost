using UnityEngine;

public class SentinelCoreDataModel : EnemyDataModel
{
    public override string Name => "Sentinel Core";

    public override string Description => "Sentinel Core to starożytny kolos o potężnej liczbie punktów życia. W przeciwieństwie do innych bossów, przemieszcza się z umiarkowaną prędkością. Zanim jednak uderzy w bazę, musi najpierw obejść całą mapę dookoła. Wykorzystaj tę długą trasę, aby zbić jego zdrowie, zanim wywoła natychmiastową przegraną.";

    public override int MaxHealth => 60000;

    public override int Loot => 500;

    public override int DamageToBase => int.MaxValue;

    public override float Speed => 1.7f;
}
