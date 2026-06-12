using System.Collections.Generic;
using UnityEngine;

public class XenoJungleMapDataModel : MapDataModel
{
    private MapInitialValues initialValues = InitialValuesResolver.resolve(MapType.XENO_JUNGLE);
    public override string Name => "Xeno Jungle";

    public override int initialCurrency => initialValues.InitialCurrency;

    public override int initialHealth => initialValues.InitialHealth;

    public override string description => "Tętniąca życiem, mroczna biosfera o neonowej kolorystyce, gdzie niebo zasłania gęste sklepienie gigantycznych, drapieżnych liści. Drogi wiją się pośród pulsujących zarodników i świecącej biomasy, a gęsta, fioletowa mgła ogranicza widoczność, sprawiając, że metalowe laboratoria GRA wyglądają jak obce ciało w tym dzikim, organicznym świecie.";

    public override List<EnemyType> mapEnemies => new List<EnemyType> { EnemyType.SPORE_ROLLER, EnemyType.VIPER_ROOT, EnemyType.REGEN_BULB };

    public override bool IsActive => false;
}
