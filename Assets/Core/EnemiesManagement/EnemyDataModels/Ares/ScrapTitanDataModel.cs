using UnityEngine;

public class ScrapTitanDataModel : EnemyDataModel
{
    public override string Name => "Scrap Titan";

    public override string Description => "Scrap Titan to potężna, krocząca machina sklecona z ciężkiego złomu i porzuconych pancerzy. Choć porusza się niezwykle ślamazarnie, nadrabia to ogromną pulą zdrowia. Nie wolno pozwolić mu zbliżyć się do celu – jego dotarcie do bazy oznacza natychmiastowy koniec gry. Pokonaj go, nim ukończy swój marsz!";

    public override int MaxHealth => 5000;

    public override int Loot => 100;

    public override int DamageToBase => int.MaxValue;

    public override float Speed => 0.8f;
}
