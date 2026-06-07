using UnityEngine;

public class GlueTowerDataModel : TowerDataModel
{
    public override string Name => "Glue Tower";
    public override string Description => "Wystrzeliwuje pociski wype³nione gêst¹, ¿r¹c¹ mazi¹ syntetyczn¹. Mimo powolnego prze³adowania, substancja natychmiast oblepia cel, redukuj¹c jego prêdkoœæ o 75% na 4 sekundy. Toksyczny sk³ad chemiczny wywo³uje poparzenia zadaj¹ce 3 obra¿eñ co 3 sekundy (przez 30 sekund), a kolejne trafienia nak³adaj¹ siê (stackuj¹), potêguj¹c ból";
    public override float Damage => 5f; 
    public override float Range => 5f;
    public override int Cost => 400;
    public override float ReloadTime => 2.5f;
}