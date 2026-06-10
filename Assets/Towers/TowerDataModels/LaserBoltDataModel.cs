using UnityEngine;

public class LaserBoltDataModel : TowerDataModel
{
    public override string Name => "Laser Bolt";

    public override string Description => "Dzia�o laserowe dalekiego zasi�gu, kt�re drastycznie skraca czas prze�adowania z ka�dym kolejnym atakiem (maksymalnie do 0.1 sekundy). Na pe�nych obrotach uwalnia niszczycielsk� seri� 10 strza��w, automatycznie wywo�uj�c przeci��enie rdzenia. Wymusza to 5-sekundowy stan bezczynno�ci potrzebny na sch�odzenie emiter�w.";

    public override float Damage => 8;

    public override float Range => 15f;

    public override int Cost => 250;

    public override float ReloadTime => 1.0f;
}
