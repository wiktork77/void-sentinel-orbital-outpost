using UnityEngine;

public class CryoColossusDataModel : EnemyDataModel
{
    public override string Name => "Cryo Colossus";

    public override string Description => "Potê¿ny tytan zmarzliny, posiadaj¹cy 35% odpornoœci na spowolnienia od ch³odu. Ka¿da wie¿a, która odwa¿y siê go zaatakowaæ, zostaje natychmiast zmro¿ona, co zmniejsza jej szybkostrzelnoœæ o 30% na 10 sekund. W momencie œmierci jego cia³o zamarza w nienaruszaln¹ bry³ê, czyni¹c go ca³kowicie nieœmiertelnym przez ostatnie 2 sekundy marszu.";

    public override int MaxHealth => 550;

    public override int Loot => 50;

    public override int DamageToBase => 20;

    public override float Speed => 1.5f;
}
