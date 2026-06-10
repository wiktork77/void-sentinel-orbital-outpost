using UnityEngine;

public class CryoColossusDataModel : EnemyDataModel
{
    public override string Name => "Cryo Colossus";

    public override string Description => "Potê¿ny tytan zmarzliny, posiadaj¹cy 35% odpornoœci na spowolnienia od ch³odu. Ka¿da wie¿a, która odwa¿y siê go zaatakowaæ, zostaje natychmiast zmro¿ona, co zwiêksza jej czas prze³adowania o 150% na 5 sekund.";

    public override int MaxHealth => 550;

    public override int Loot => 50;

    public override int DamageToBase => 20;

    public override float Speed => 1.5f;
}
