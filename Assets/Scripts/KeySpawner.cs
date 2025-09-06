using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField] List<Transform> possibleSpawnPoints = new();
    [SerializeField] GameObject keyPrefab;

    void Start()
    {
        foreach (Transform spawnPoint in possibleSpawnPoints)
        {
            Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
