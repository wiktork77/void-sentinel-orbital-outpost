using UnityEngine;

public class LaserBoltDataModel : TowerDataModel
{
    public override string Name => "Laser Bolt";

    public override string Description => "Dzia³o laserowe dalekiego zasiêgu, które drastycznie skraca czas prze³adowania z ka¿dym kolejnym atakiem (maksymalnie do 0.1 sekundy). Na pe³nych obrotach uwalnia niszczycielsk¹ seriê 10 strza³ów, automatycznie wywo³uj¹c przeci¹¿enie rdzenia. Wymusza to 5-sekundowy stan bezczynnoœci potrzebny na sch³odzenie emiterów.";

    public override float Damage => 8;

    public override float Range => 15f;

    public override int Cost => 250;

    public override float ReloadTime => 1.0f;
}
