using UnityEngine;

public class SlowTowerDataModel : TowerDataModel
{
    public override string Name => "Slow Tower";

    public override string Description => "Zaawansowany generator subatomowy, który manipuluje kinetyką cząsteczek w swoim otoczeniu. Wieża co 0.5 sekundy emituje potężny impuls kriogeniczny, tworząc wokół siebie stabilną, kolistą strefę zerowej temperatury. Przeciwnicy wewnątrz kręgu zostają spowolnieni o 50%, a paraliżujące zimno działa na nich jeszcze przez 1.5 sekundy po ucieczce z mroźnej strefy.";

    public override float Damage => 0f;

    public override float Range => 8f;

    public override int Cost => 300;

    public override float ReloadTime => 0.25f;
}
