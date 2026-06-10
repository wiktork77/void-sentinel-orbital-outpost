using UnityEngine;

public class CryoColossusDataModel : EnemyDataModel
{
    public override string Name => "Cryo Colossus";

    public override string Description => "Pot�ny tytan zmarzliny, posiadaj�cy 35% odporno�ci na spowolnienia od ch�odu. Ka�da wie�a, kt�ra odwa�y si� go zaatakowa�, zostaje natychmiast zmro�ona, co zwi�ksza jej czas prze�adowania o 150% na 5 sekund.";

    public override int MaxHealth => 550;

    public override int Loot => 50;

    public override int DamageToBase => 20;

    public override float Speed => 1.5f;
}
