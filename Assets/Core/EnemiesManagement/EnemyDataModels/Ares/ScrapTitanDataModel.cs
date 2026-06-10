using UnityEngine;

public class ScrapTitanDataModel : EnemyDataModel
{
    public override string Name => "Scrap Titan";

    public override string Description => "Scrap Titan to potê¿na, krocz¹ca machina sklecona z ciê¿kiego z³omu i porzuconych pancerzy. Choæ porusza siê niezwykle œlamatarnie, nadrabia to ogromn¹ pul¹ zdrowia. Nie wolno pozwoliæ mu zbli¿yæ siê do celu – jego dotarcie do bazy oznacza natychmiastowy koniec gry. Pokonaj go, nim ukoñczy swój marsz!";

    public override int MaxHealth => 5000;

    public override int Loot => 100;

    public override int DamageToBase => int.MaxValue;

    public override float Speed => 0.8f;
}
