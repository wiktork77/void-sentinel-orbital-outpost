using UnityEngine;

public class FrostDrifterDataModel : EnemyDataModel
{
    public override string Name => "Frost Drifter";

    public override string Description => "Ulotna i niezwykle agresywna manifestacja skondensowanej energii kriogenicznej, która potrafi b³yskawicznie przemieszczaæ siê po polu bitwy. Poniewa¿ jego struktura sk³ada siê z czystego lodu, byt ten wykazuje 65% odpornoœci na spowolnienia wywo³ane ch³odem. Zwyk³e wie¿e mro¿¹ce nie zdo³aj¹ go powstrzymaæ przed zadaniem potê¿nych uszkodzeñ strukturze bazy.";

    public override int MaxHealth => 65;

    public override int Loot => 5;

    public override int DamageToBase => 7;

    public override float Speed => 5f;
}
