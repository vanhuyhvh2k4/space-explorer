using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;

    [SerializeField] private int waveNumber;

    [SerializeField] private List<Wave> waves;
    
    [System.Serializable]
    public class Wave
    {
        public GameObject prefab;
        public float spawnerTimer;
        public float spawnInterval;
        public int objectPerWave;
        public int spawnedObjectCount;
    }
    void Update()
    {
        waves[waveNumber].spawnerTimer += Time.deltaTime * PlayerController.Instance.boost;
        if (waves[waveNumber].spawnerTimer >= waves[waveNumber].spawnInterval)
        {
            waves[waveNumber].spawnerTimer = 0f;
            SpawnObject();
        }

        if (waves[waveNumber].spawnedObjectCount >= waves[waveNumber].objectPerWave)
        {
            waves[waveNumber].spawnedObjectCount = 0;
            waveNumber++;
            if (waveNumber >= waves.Count)
            {
                waveNumber = 0;
            }
        }
    }

    private void SpawnObject()
    {
        Instantiate(waves[waveNumber].prefab, RandomSpawnPoint(), transform.rotation);
        waves[waveNumber].spawnedObjectCount++;
    }

    private Vector2 RandomSpawnPoint()
    {
        Vector2 spawnPoint;

        spawnPoint.x = minPos.position.x;
        spawnPoint.y = Random.Range(minPos.position.y, maxPos.position.y);

        return spawnPoint;
    }
}