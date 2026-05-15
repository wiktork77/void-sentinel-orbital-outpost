using UnityEngine;

public class RustWalkerDataModel : EnemyDataModel
{
    public override string Name => "Rust Walker";

    public override string Description => temporaryDescription;

    public override int MaxHealth => 120;

    public override int Loot => 5;

    public override int DamageToBase => 3;

    public override float Speed =>  2f;
}
