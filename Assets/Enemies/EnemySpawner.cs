using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectPrefab; 
    public Transform centerObject;
    public float spawnDistance = 50f; 
    public float spawnInterval = 2f; 
    public int spawnCount = 10; 

    private int currentSpawnCount;
    private float spawnTimer;

    private void Start()
    {
        currentSpawnCount = 0;
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (currentSpawnCount < spawnCount && spawnTimer <= 0f)
        {
            SpawnObject();
            currentSpawnCount++;
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnObject()
    {
        Vector3 randomDirection = Random.insideUnitSphere.normalized * spawnDistance;
        Vector3 spawnPosition = centerObject.position + randomDirection;

        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }
}
