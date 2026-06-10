using UnityEngine;

public class SporeRollerDataModel : EnemyDataModel
{
    public override string Name => "Spore Roller";

    public override string Description => "Podstawowa bio-jednostka d¿ungli. Ten naturalny turlacz twardnieje podczas ruchu i jego prêdkoœæ wzrasta tym bardziej, im d³u¿sz¹ odleg³oœæ pokona, czerpi¹c pêd z w³asnych obrotów. Im póŸniej go zatrzymasz, tym trudniej bêdzie to zrobiæ.";

    public override int MaxHealth => 75;

    public override int Loot => 1;

    public override int DamageToBase => 10;

    public override float Speed => 2f;
}
