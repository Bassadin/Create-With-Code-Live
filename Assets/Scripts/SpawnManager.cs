using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float xSpawnRange = 13f;
    public float zSpawnOffset = 2f;

    public float startDelay = 1.5f;
    public float spawnInterval = 2.0f;

    private void Start() {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        Instantiate(
                animalPrefabs[Random.Range(0, animalPrefabs.Length)],
                transform.position + new Vector3(Random.Range(-xSpawnRange, xSpawnRange), 0, zSpawnOffset),
                transform.rotation
                );
    }
}
