using UnityEngine;

public class RegenBulbDataModel : EnemyDataModel
{
    public override string Name => "Regen Bulb";

    public override string Description => temporaryDescription;

    public override int MaxHealth => 850;

    public override int Loot => 50;

    public override int DamageToBase => 25;

    public override float Speed => 1.9f;
}
