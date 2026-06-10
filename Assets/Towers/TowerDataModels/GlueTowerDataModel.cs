using UnityEngine;

public class GlueTowerDataModel : TowerDataModel
{
    public override string Name => "Glue Tower";
    public override string Description => "Wystrzeliwuje pociski wype�nione g�st�, �r�c� mazi� syntetyczn�. Mimo powolnego prze�adowania, substancja natychmiast oblepia cel, redukuj�c jego pr�dko�� o 75% na 4 sekundy. Toksyczny sk�ad chemiczny wywo�uje poparzenia zadaj�ce 3 obra�e� co 3 sekundy (przez 30 sekund), a kolejne trafienia nak�adaj� si� (stackuj�), pot�guj�c b�l";
    public override float Damage => 5f; 
    public override float Range => 5f;
    public override int Cost => 300;
    public override float ReloadTime => 2.5f;
}