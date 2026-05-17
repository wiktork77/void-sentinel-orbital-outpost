using UnityEngine;

public class LaserBoltDataModel : TowerDataModel
{
    public override string Name => "Laser Bolt";

    public override string Description => temporaryDescription;

    public override float Damage => 15;

    public override float Range => 15f;

    public override int Cost => 250;

    public override float ReloadTime => 0.2f;
}
