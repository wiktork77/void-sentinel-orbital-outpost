using UnityEngine;

public class CryoColossusDataModel : EnemyDataModel
{
    public override string Name => "Cryo Colossus";

    public override string Description => "Potężny tytan zmarzliny, posiadający 35% odporności na spowolnienia od chłodu. Każda wieża, która odważy się go zaatakować, zostaje natychmiast zmrożona, co zwiększa jej czas przeładowania o 150% na 5 sekund.";

    public override int MaxHealth => 550;

    public override int Loot => 50;

    public override int DamageToBase => 20;

    public override float Speed => 1.5f;
}
