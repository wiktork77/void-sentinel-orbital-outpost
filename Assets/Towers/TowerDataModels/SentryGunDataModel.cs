using UnityEngine;

public class SentryGunDataModel : TowerDataModel
{
    public override string Name => "Sentry Gun";

    public override string Description => "Wielkokalibrowe działo obronne, które wystrzeliwuje pociski o ogromnej masie kinetycznej. Choć mechanizm przeładowania wymaga 1.5 sekundy, potężna siła uderzenia zadaje drastyczne obrażenia na krótkim dystansie. Każde trafienie ma 20% szansy na wywołanie fali uderzeniowej, która ogłusza cel na 0.5 sekundy.";

    public override float Damage => 60f;

    public override float Range => 6.5f;

    public override int Cost => 150;

    public override float ReloadTime => 1.5f;
}
