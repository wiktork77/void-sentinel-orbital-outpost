using UnityEngine;

public class ViperRootDataModel : EnemyDataModel
{
    public override string Name => "Viper Root";

    public override string Description => "Błyskawiczny drapieżnik flory dżungli, który jest całkowicie odporny na wszelkie efekty spowolnienia oraz ogłuszenia (stun). Co więcej, jego zmutowany metabolizm natychmiast absorbuje wrogie toksyny, przez co każda próba spowolnienia drastycznie zwiększa jego prędkość ruchu. Przeciwko temu potworowi działa wyłącznie czysta, niszczycielska siła rażenia.";

    public override int MaxHealth => 170;

    public override int Loot => 10;

    public override int DamageToBase => 10;

    public override float Speed => 4.5f;
}
