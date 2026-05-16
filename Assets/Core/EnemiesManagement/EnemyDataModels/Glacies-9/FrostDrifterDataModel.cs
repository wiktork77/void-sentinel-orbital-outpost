using UnityEngine;

public class FrostDrifterDataModel : EnemyDataModel
{
    public override string Name => "Frost Drifter";

    public override string Description => temporaryDescription;

    public override int MaxHealth => 50;

    public override int Loot => 3;

    public override int DamageToBase => 7;

    public override float Speed => 5f;
}
