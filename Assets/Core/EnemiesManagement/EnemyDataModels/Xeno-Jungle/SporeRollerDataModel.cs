using UnityEngine;

public class SporeRollerDataModel : EnemyDataModel
{
    public override string Name => "Spore Roller";

    public override string Description => temporaryDescription;

    public override int MaxHealth => 75;

    public override int Loot => 1;

    public override int DamageToBase => 10;

    public override float Speed => 2f;
}
