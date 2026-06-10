using UnityEngine;

public class SentinelCoreDataModel : EnemyDataModel
{
    public override string Name => "Sentinel Core";

    public override string Description => "Sentinel Core to staro¿ytny kolos o potê¿nej liczbie punktów ¿ycia. W przeciwieñstwie do innych bossów, przemieszcza siê z umiarkowan¹ prêdkoœci¹. Zanim jednak uderzy w bazê, musi najpierw obejœæ ca³¹ mapê dooko³a. Wykorzystaj tê d³ug¹ trasê, aby zbiæ jego zdrowie, zanim wywo³a natychmiastow¹ przegran¹.";

    public override int MaxHealth => 1500;

    public override int Loot => 500;

    public override int DamageToBase => int.MaxValue;

    public override float Speed => 1.7f;
}
