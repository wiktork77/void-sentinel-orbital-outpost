using UnityEngine;

public class IceCrawlerDataModel : EnemyDataModel
{
    public override string Name => "Ice Crawler";

    public override string Description => "Pradawny, opancerzony stawon�g, ca�kowicie przystosowany do skrajnych mroz�w. Wykazuje a� 95% odporno�ci na spowolnienia ch�odem, a ka�de przej�cie przez pole lodu na mapie permanentnie zwi�ksza jego pr�dko��. Nale�y eliminowa� go za pomoc� wie� fizycznych lub energetycznych, zanim zbytnio si� rozp�dzi.";

    public override int MaxHealth => 350;

    public override int Loot => 35;

    public override int DamageToBase => 10;

    public override float Speed => 1f;
}
