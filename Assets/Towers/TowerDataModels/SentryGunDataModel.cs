using UnityEngine;

public class SentryGunDataModel : TowerDataModel
{
    public override string Name => "Sentry Gun";

    public override string Description => "Wielkokalibrowe dzia³o obronne, które wystrzeliwuje pociski o ogromnej masie kinetycznej. Choæ mechanizm prze³adowania wymaga 1.5 sekundy, potê¿na si³a uderzenia zadaje drastyczne obra¿enia na krótkim dystansie. Ka¿de trafienie ma 20% szansy na wywo³anie fali uderzeniowej, która og³usza cel na 0.5 sekundy.";

    public override float Damage => 60f;

    public override float Range => 6.5f;

    public override int Cost => 150;

    public override float ReloadTime => 1.5f;
}
