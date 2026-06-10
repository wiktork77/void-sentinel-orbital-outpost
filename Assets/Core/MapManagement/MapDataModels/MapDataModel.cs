using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapDataModel
{
    public abstract string Name { get; }
    public abstract int initialCurrency {  get; }
    public abstract int initialHealth { get; }
    public abstract string description { get; }

    public abstract List<EnemyType> mapEnemies { get; }

    public virtual bool IsActive => true;
}
