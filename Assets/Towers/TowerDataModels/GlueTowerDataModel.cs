using UnityEngine;

public class GlueTowerDataModel : TowerDataModel
{
    public override string Name => "Glue Tower";
    public override string Description => "Wystrzeliwuje pociski wypełnione gęstą, żrącą mazią syntetyczną. Mimo powolnego przeładowania, substancja natychmiast oblepia cel, redukując jego prędkość o 75% na 4 sekundy. Toksyczny skład chemiczny wywołuje poparzenia zadające 3 obrażeń co 3 sekundy (przez 30 sekund), a kolejne trafienia nakładają się (stackują), potęgując ból.";
    public override float Damage => 5f; 
    public override float Range => 5f;
    public override int Cost => 300;
    public override float ReloadTime => 2.5f;
}