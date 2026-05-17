using UnityEngine;

public class SentryGunDataModel : TowerDataModel
{
    public override string Name => "Sentry Gun";

    public override string Description => temporaryDescription;

    public override float Damage => 50f;

    public override float Range => 7.5f;

    public override int Cost => 125;

    public override float ReloadTime => 0.7f;
}
