using UnityEngine;

public class FrostDrifterDataModel : EnemyDataModel
{
    public override string Name => "Frost Drifter";

    public override string Description => "Ulotna i niezwykle agresywna manifestacja skondensowanej energii kriogenicznej, kt�ra potrafi b�yskawicznie przemieszcza� si� po polu bitwy. Poniewa� jego struktura sk�ada si� z czystego lodu, byt ten wykazuje 65% odporno�ci na spowolnienia wywo�ane ch�odem. Zwyk�e wie�e mro��ce nie zdo�aj� go powstrzyma� przed zadaniem pot�nych uszkodze� strukturze bazy.";

    public override int MaxHealth => 65;

    public override int Loot => 10;

    public override int DamageToBase => 7;

    public override float Speed => 5f;
}
