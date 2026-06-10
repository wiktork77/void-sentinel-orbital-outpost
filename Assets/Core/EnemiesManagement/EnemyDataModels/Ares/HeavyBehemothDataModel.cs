using UnityEngine;

public class HeavyBehemothDataModel : EnemyDataModel
{
    public override string Name => "Heavy Behemoth";

    public override string Description => "Przera¿aj¹cy biomechaniczny kolos, stworzony z myœl¹ o prze³amywaniu najciê¿szych linii obronnych. Posiada niesamowit¹ zdolnoœæ replikacji tkanek – jeœli nie otrzyma ¿adnych obra¿eñ przez 3 sekundy, jego rany natychmiast siê zasklepiaj¹, regeneruj¹c 30 HP co sekundê. Do jego eliminacji wymagany jest nieustanny, skoncentrowany ostrza³.";

    public override int MaxHealth => 300;

    public override int Loot => 15;

    public override int DamageToBase => 10;

    public override float Speed => 1.2f;
}
