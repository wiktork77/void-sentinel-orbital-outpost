using UnityEngine;

public class LaserBoltDataModel : TowerDataModel
{
    public override string Name => "Laser Bolt";

    public override string Description => temporaryDescription;

    public override float Damage => 20;

    public override float Range => 50f;

    public override int Cost => 200;

    public override float ReloadTime => 0.4f;
}
