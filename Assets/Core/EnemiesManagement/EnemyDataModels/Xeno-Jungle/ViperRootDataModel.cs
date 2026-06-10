using UnityEngine;

public class ViperRootDataModel : EnemyDataModel
{
    public override string Name => "Viper Root";

    public override string Description => "B³yskawiczny drapie¿nik flory d¿ungli, który jest ca³kowicie odporny na wszelkie efekty spowolnienia oraz og³uszenia (stun). Co wiêcej, jego zmutowany metabolizm natychmiast absorbuje wrogie toksyny, przez co ka¿da próba spowolnienia drastycznie zwiêksza jego prêdkoœæ ruchu. Przeciwko temu potworowi dzia³a wy³¹cznie czysta, niszczycielska si³a ra¿enia.";

    public override int MaxHealth => 170;

    public override int Loot => 10;

    public override int DamageToBase => 10;

    public override float Speed => 4.5f;
}
