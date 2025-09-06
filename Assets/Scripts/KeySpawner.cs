using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField] List<Transform> possibleSpawnPoints = new();
    [SerializeField] GameObject keyPrefab;
    int keysCollected;

    void Start()
    {
        keysCollected = 0;
        foreach (Transform spawnPoint in possibleSpawnPoints)
        {
            Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);
        }
        Events.OnKeyCollected += KeyCollected;
        Events.OnAnnounceUpdate?.Invoke(GetKeyAmountText());
    }
    private void KeyCollected()
    {
        keysCollected++;
        if (keysCollected < possibleSpawnPoints.Count)
        {    
            Events.OnAnnounceUpdate?.Invoke(GetKeyAmountText());
        }
        else
        {
            Events.OnAnnounceUpdateWithColor?.Invoke("You collected all the keys! you can now escape!", Color.green);
        }
    }

    string GetKeyAmountText()
    {
        return $"You have to find {keysCollected}/{possibleSpawnPoints.Count}";
    }

    private void OnDestroy()
    {
        Events.OnKeyCollected -= KeyCollected;
    }

}
