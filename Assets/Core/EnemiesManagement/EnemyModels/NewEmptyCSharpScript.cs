using System;
using UnityEngine;

public interface IBoss
{
    public void SetOnBossTakeDamage(Action<int, int> action);
}
