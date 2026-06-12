using UnityEngine;

public class FrostDrifterDataModel : EnemyDataModel
{
    public override string Name => "Frost Drifter";

    public override string Description => "Ulotna i niezwykle agresywna manifestacja skondensowanej energii kriogenicznej, która potrafi błyskawicznie przemieszczać się po polu bitwy. Ponieważ jego struktura składa się z czystego lodu, byt ten wykazuje 65% odporności na spowolnienia wywołane chłodem. Zwykłe wieże mrożące nie zdołają go powstrzymać przed zadaniem potężnych uszkodzeń strukturze bazy.";

    public override int MaxHealth => 65;

    public override int Loot => 30;

    public override int DamageToBase => 7;

    public override float Speed => 5f;
}
