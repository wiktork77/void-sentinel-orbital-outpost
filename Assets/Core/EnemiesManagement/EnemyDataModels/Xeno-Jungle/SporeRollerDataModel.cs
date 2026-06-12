using UnityEngine;

public class SporeRollerDataModel : EnemyDataModel
{
    public override string Name => "Spore Roller";

    public override string Description => "Podstawowa bio-jednostka dżungli. Ten naturalny turlacz twardnieje podczas ruchu i jego prędkość wzrasta tym bardziej, im dłuższą odległość pokona, czerpiąc pęd z własnych obrotów. Im później go zatrzymasz, tym trudniej będzie to zrobić.";

    public override int MaxHealth => 75;

    public override int Loot => 1;

    public override int DamageToBase => 10;

    public override float Speed => 2f;
}
