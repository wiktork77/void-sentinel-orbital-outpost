using System.Collections.Generic;
using UnityEngine;

public class GlaciesMapDataModel : MapDataModel
{
    private MapInitialValues initialValues = InitialValuesResolver.resolve(MapType.GLACIES_X);

    public override string Name => "Glacies-X";

    public override int initialCurrency => initialValues.InitialCurrency;

    public override int initialHealth => initialValues.InitialHealth;

    public override string description => "Surowy, b³êkitno-bia³y glob pokryty wieczn¹ zmarzlin¹ i gigantycznymi lodowcami, które lœni¹ pod wp³ywem s³abego œwiat³a odleg³ej gwiazdy. Powierzchniê planety przecinaj¹ krystaliczne, lustrzane œcie¿ki oraz szczeliny, z których wydobywa siê b³êkitna poœwiata emitowana przez ukryte g³êboko pod lodem z³o¿a energii.";

    public override List<EnemyType> mapEnemies => new List<EnemyType> { EnemyType.FROST_DRIFTER, EnemyType.ICE_CRAWLER, EnemyType.CRYO_COLLOSSUS, EnemyType.SENTINEL_CORE_BOSS };
}
