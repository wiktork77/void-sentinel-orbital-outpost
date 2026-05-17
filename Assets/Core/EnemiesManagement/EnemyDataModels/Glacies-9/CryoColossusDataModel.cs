using UnityEngine;

public class CryoColossusDataModel : EnemyDataModel
{
    public override string Name => "Cryo Colossus";

    public override string Description => temporaryDescription;

    public override int MaxHealth => 550;

    public override int Loot => 50;

    public override int DamageToBase => 20;

    public override float Speed => 1.5f;
}
