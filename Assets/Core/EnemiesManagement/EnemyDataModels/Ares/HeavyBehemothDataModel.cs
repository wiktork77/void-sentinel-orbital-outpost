using UnityEngine;

public class HeavyBehemothDataModel : EnemyDataModel
{
    public override string Name => "Heavy Behemoth";

    public override string Description => "Przera�aj�cy biomechaniczny kolos, stworzony z my�l� o prze�amywaniu najci�szych linii obronnych. Posiada niesamowit� zdolno�� replikacji tkanek � je�li nie otrzyma �adnych obra�e� przez 3.5 sekundy, jego rany natychmiast si� zasklepiaj�, regeneruj�c 50 HP co sekund�. Do jego eliminacji wymagany jest nieustanny, skoncentrowany ostrza�.";

    public override int MaxHealth => 500;

    public override int Loot => 70;

    public override int DamageToBase => 10;

    public override float Speed => 1f;
}
