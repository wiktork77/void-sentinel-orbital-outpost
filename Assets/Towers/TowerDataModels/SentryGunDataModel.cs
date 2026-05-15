using UnityEngine;

public class SentryGunDataModel : TowerDataModel
{
    public override string Name => "Sentry Gun";

    public override string Description => temporaryDescription;

    public override float Damage => 40f;

    public override float Range => 4f;

    public override int Cost => 150;

    public override float ReloadTime => 0.8f;
}
