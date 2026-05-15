using UnityEngine;

public class SlowTowerDataModel : TowerDataModel
{
    public override string Name => "Slow Tower";

    public override string Description => temporaryDescription;

    public override float Damage => 0f;

    public override float Range => 8f;

    public override int Cost => 300;

    public override float ReloadTime => 0.5f;
}
