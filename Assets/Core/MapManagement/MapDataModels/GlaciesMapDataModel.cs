using System.Collections.Generic;
using UnityEngine;

public class GlaciesMapDataModel : MapDataModel
{
    private MapInitialValues initialValues = InitialValuesResolver.resolve(MapType.GLACIES_X);

    public override string Name => "Glacies-X";

    public override int initialCurrency => initialValues.InitialCurrency;

    public override int initialHealth => initialValues.InitialHealth;

    public override string description => "Surowy, błękitno-biały glob pokryty wieczną zmarzliną i gigantycznymi lodowcami, które lśnią pod wpływem słabego światła odległej gwiazdy. Powierzchnię planety przecinają krystaliczne, lustrzane ścieżki oraz szczeliny, z których wydobywa się błękitna poświata emitowana przez ukryte głęboko pod lodem złoża energii.";

    public override List<EnemyType> mapEnemies => new List<EnemyType> { EnemyType.FROST_DRIFTER, EnemyType.ICE_CRAWLER, EnemyType.CRYO_COLLOSSUS, EnemyType.SENTINEL_CORE_BOSS };
}
