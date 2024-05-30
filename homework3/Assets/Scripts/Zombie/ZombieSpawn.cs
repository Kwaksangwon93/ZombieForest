using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int maxZombies = 50;
    
    private int currentZombieCount = 0;

    void Start()
    {
        for (int i = 0; i < maxZombies; i++)
        {
            SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        if (currentZombieCount < maxZombies)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-40, 80), 20, Random.Range(-20, 90));

            Instantiate(zombiePrefab, randomPosition, Quaternion.identity);
            currentZombieCount++;
        }
    }
}
