using UnityEngine;

public class RegenBulbDataModel : EnemyDataModel
{
    public override string Name => "Regen Bulb";

    public override string Description => "Monstrualny, ¿ywy ekosystem d¿ungli o niemal nieskoñczonych zdolnoœciach przetrwania. Potwór posiada sta³¹ regeneracjê na poziomie 20 HP co sekundê, która drastycznie wzrasta wraz ze spadkiem jego punktów zdrowia. Im mocniej jest zraniony, tym szybciej jego tkanki siê odbudowuj¹, zmuszaj¹c do u¿ycia maksymalnej si³y ognia w koñcowej fazie walki.";

    public override int MaxHealth => 850;

    public override int Loot => 50;

    public override int DamageToBase => 25;

    public override float Speed => 1.9f;
}
