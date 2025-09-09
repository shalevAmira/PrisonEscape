using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField] List<Transform> possibleSpawnPoints = new();
    [SerializeField] GameObject keyPrefab;
    Color allKeysCollectedMessageColor = Color.green;
    int keysCollected = 0;

    void Start()
    {
         
        foreach (Transform spawnPoint in possibleSpawnPoints)
        {
            Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);
        }
        Events.OnKeyCollected += KeyCollected;
        Events.AnnounceUpdate?.Invoke(GetKeyAmountText());
    }

    private void KeyCollected()
    {
        keysCollected++;
        if (keysCollected < possibleSpawnPoints.Count)
        {    
            Events.AnnounceUpdate?.Invoke(GetKeyAmountText());
        }
        else
        {
            Events.AnnounceUpdateWithColor?.Invoke("You collected all the keys! you can now escape!", allKeysCollectedMessageColor);
            Events.OpenDoor?.Invoke();
        }
    }

    string GetKeyAmountText()
    {
        return $"You have to find {keysCollected}/{possibleSpawnPoints.Count} keys.";
    }

    private void OnDestroy()
    {
        Events.OnKeyCollected -= KeyCollected;
    }
}
