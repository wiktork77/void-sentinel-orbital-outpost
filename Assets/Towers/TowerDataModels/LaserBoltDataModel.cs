using UnityEngine;

public class LaserBoltDataModel : TowerDataModel
{
    public override string Name => "Laser Bolt";

    public override string Description => "Działo laserowe dalekiego zasięgu, które drastycznie skraca czas przeładowania z każdym kolejnym atakiem (maksymalnie do 0.1 sekundy). Na pełnych obrotach uwalnia niszczycielską serię 10 strzałów, automatycznie wywołując przeciążenie rdzenia. Wymusza to 5-sekundowy stan bezczynności potrzebny na schłodzenie emiterów.";

    public override float Damage => 8;

    public override float Range => 15f;

    public override int Cost => 250;

    public override float ReloadTime => 1.0f;
}
