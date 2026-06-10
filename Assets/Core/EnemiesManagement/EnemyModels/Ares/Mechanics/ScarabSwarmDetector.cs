using System.Collections.Generic;
using UnityEngine;

public class ScarabSwarmDetector : MonoBehaviour
{
    private readonly HashSet<ScarabDroneEnemyScript> _nearbyAllies = new();
    private ScarabDroneEnemyScript _owner;

    private void Awake()
    {
        _owner = GetComponentInParent<ScarabDroneEnemyScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ScarabDroneEnemyScript>(out var ally) && ally != _owner)
        {
            _nearbyAllies.Add(ally);
            _owner.OnSwarmChanged(_nearbyAllies.Count);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<ScarabDroneEnemyScript>(out var ally))
        {
            _nearbyAllies.Remove(ally);
            _owner.OnSwarmChanged(_nearbyAllies.Count);
        }
    }
}