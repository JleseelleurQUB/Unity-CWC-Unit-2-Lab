using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 20.0f;
    private float spawnPosX = 30.0f;
    private float spawnRangeZ = 20.0f;
    private float spawnDelay = 2.0f;
    private float spawnInterval = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Repeats animal spawning function every interval after delay
        InvokeRepeating("SpawnRandomAnimal", spawnDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", spawnDelay, spawnInterval * 2);
        InvokeRepeating("SpawnRightAnimal", spawnDelay, spawnInterval * 2);
    }


    void SpawnRandomAnimal()
    {
        // Randomly generates animal type and spawn position
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 leftSpawnPos = new Vector3(-spawnPosX, 0, Random.Range(-1, spawnRangeZ));
        Instantiate(animalPrefabs[animalIndex], leftSpawnPos, Quaternion.LookRotation(Vector3.right));
    }

    void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 rightSpawnPos = new Vector3(spawnPosX, 0, Random.Range(-1, spawnRangeZ));
        Instantiate(animalPrefabs[animalIndex], rightSpawnPos, Quaternion.LookRotation(Vector3.left));
    }
}
