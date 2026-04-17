using UnityEngine;

public class SpawnService
{
    private EnemyRegistrySO enemyRegistry;

    public SpawnService(EnemyRegistrySO enemyRegistry)
    {
        this.enemyRegistry = enemyRegistry;
    }


    public EnemyScript spawnEnemy(EnemyType enemyType, Vector3 position)
    {
        GameObject prefab = enemyRegistry.getPrefab(enemyType);
        GameObject spawnedEnemy = Object.Instantiate(prefab, position, Quaternion.identity);
        EnemyScript enemyScript = spawnedEnemy.GetComponent<EnemyScript>();

        return enemyScript;
    }
}
