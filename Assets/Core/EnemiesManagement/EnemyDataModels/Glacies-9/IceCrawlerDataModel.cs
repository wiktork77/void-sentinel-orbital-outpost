using UnityEngine;

public class IceCrawlerDataModel : EnemyDataModel
{
    public override string Name => "Ice Crawler";

    public override string Description => "Pradawny, opancerzony stawonóg, całkowicie przystosowany do skrajnych mrozów. Wykazuje aż 95% odporności na spowolnienia chłodem, a każde przejście przez pole lodu na mapie permanentnie zwiększa jego prędkość. Należy eliminować go za pomocą wież fizycznych lub energetycznych, zanim zbytnio się rozpędzi.";

    public override int MaxHealth => 350;

    public override int Loot => 35;

    public override int DamageToBase => 10;

    public override float Speed => 1f;
}
