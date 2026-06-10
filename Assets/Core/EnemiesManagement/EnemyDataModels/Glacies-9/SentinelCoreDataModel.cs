using UnityEngine;

public class SentinelCoreDataModel : EnemyDataModel
{
    public override string Name => "Sentinel Core";

    public override string Description => "Sentinel Core to staro�ytny kolos o pot�nej liczbie punkt�w �ycia. W przeciwie�stwie do innych boss�w, przemieszcza si� z umiarkowan� pr�dko�ci�. Zanim jednak uderzy w baz�, musi najpierw obej�� ca�� map� dooko�a. Wykorzystaj t� d�ug� tras�, aby zbi� jego zdrowie, zanim wywo�a natychmiastow� przegran�.";

    public override int MaxHealth => 2000;

    public override int Loot => 500;

    public override int DamageToBase => int.MaxValue;

    public override float Speed => 1.7f;
}
