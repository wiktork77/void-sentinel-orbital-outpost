using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject mobPrefab;      // Tu wrzuć niebieski prefab robota
    public Transform[] waypoints;     // Tu w edytorze wrzuć swoje punkty point1-6
    public float spawnInterval = 5;   // Zmieniliśmy na 5 sekund, tak jak chciałeś
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        if (timer < spawnInterval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnNewMob();
            timer = 0;
        }
    }

    void SpawnNewMob()
    {
        // 1. Tworzymy robota
        GameObject newMob = Instantiate(mobPrefab, transform.position, transform.rotation);

        // 2. SZTUCZKA: Pobieramy skrypt z tego robota i dajemy mu punkty trasy
        MobScript script = newMob.GetComponent<MobScript>();
        
        if (script != null)
        {
            script.points = waypoints; // Przekazujemy trasę do robota
        }
    }
}
