using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float xSpawnRange = 13f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            spawnRandomAnimal();
        }
    }

    void spawnRandomAnimal()
    {
        Instantiate(
                animalPrefabs[Random.Range(0, animalPrefabs.Length)],
                transform.position + new Vector3(Random.Range(-xSpawnRange, xSpawnRange), 0, 0),
                transform.rotation
                );
    }
}
