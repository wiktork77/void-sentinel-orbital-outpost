using UnityEngine;

public class ViperRootDataModel : EnemyDataModel
{
    public override string Name => "Viper Root";

    public override string Description => temporaryDescription;

    public override int MaxHealth => 170;

    public override int Loot => 10;

    public override int DamageToBase => 10;

    public override float Speed => 4.5f;
}
