using UnityEngine;

public class SlowTowerDataModel : TowerDataModel
{
    public override string Name => "Slow Tower";

    public override string Description => "Zaawansowany generator subatomowy, który manipuluje kinetyk¹ cz¹steczek w swoim otoczeniu. Wie¿a co 0.5 sekundy emituje potê¿ny impuls kriogeniczny, tworz¹c wokó³ siebie stabiln¹, kolist¹ strefê zerowej temperatury. Przeciwnicy wewn¹trz krêgu zostaj¹ spowolnieni o 50%, a parali¿uj¹ce zimno dzia³a na nich jeszcze przez 1.5 sekundy po ucieczce z mroŸnej strefy.";

    public override float Damage => 0f;

    public override float Range => 8f;

    public override int Cost => 300;

    public override float ReloadTime => 0.5f;
}
