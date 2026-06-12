using UnityEngine;

public class HeavyBehemothDataModel : EnemyDataModel
{
    public override string Name => "Heavy Behemoth";

    public override string Description => "Przerażający biomechaniczny kolos, stworzony z myślą o przełamywaniu najcięższych linii obronnych. Posiada niesamowitą zdolność replikacji tkanek – jeśli nie otrzyma żadnych obrażeń przez 3.5 sekundy, jego rany natychmiast się zasklepiają, regenerując 50 HP co sekundę. Do jego eliminacji wymagany jest nieustanny, skoncentrowany ostrzał.";

    public override int MaxHealth => 500;

    public override int Loot => 70;

    public override int DamageToBase => 10;

    public override float Speed => 1f;
}
