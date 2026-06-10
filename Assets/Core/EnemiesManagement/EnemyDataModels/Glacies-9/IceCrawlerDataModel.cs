using UnityEngine;

public class IceCrawlerDataModel : EnemyDataModel
{
    public override string Name => "Ice Crawler";

    public override string Description => "Pradawny, opancerzony stawonóg, ca³kowicie przystosowany do skrajnych mrozów. Wykazuje a¿ 95% odpornoœci na spowolnienia ch³odem, a ka¿de przejœcie przez pole lodu na mapie permanentnie zwiêksza jego prêdkoœæ. Nale¿y eliminowaæ go za pomoc¹ wie¿ fizycznych lub energetycznych, zanim zbytnio siê rozpêdzi.";

    public override int MaxHealth => 350;

    public override int Loot => 25;

    public override int DamageToBase => 10;

    public override float Speed => 1f;
}
