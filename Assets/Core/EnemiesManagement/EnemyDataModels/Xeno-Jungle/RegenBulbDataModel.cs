using UnityEngine;

public class RegenBulbDataModel : EnemyDataModel
{
    public override string Name => "Regen Bulb";

    public override string Description => "Monstrualny, żywy ekosystem dżungli o niemal nieskończonych zdolnościach przetrwania. Potwór posiada stałą regenerację na poziomie 20 HP co sekundę, która drastycznie wzrasta wraz ze spadkiem jego punktów zdrowia. Im mocniej jest zraniony, tym szybciej jego tkanki się odbudowują, zmuszając do użycia maksymalnej siły ognia w końcowej fazie walki.";

    public override int MaxHealth => 850;

    public override int Loot => 50;

    public override int DamageToBase => 25;

    public override float Speed => 1.9f;
}
