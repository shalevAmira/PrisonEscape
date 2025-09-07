using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Sprite openDoorSprite;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Events.OnKeyCollected += CheckIfShouldOpenDoor;
    }

    private void OnDisable()
    {
        Events.OnKeyCollected -= CheckIfShouldOpenDoor;
    }

    private void CheckIfShouldOpenDoor()
    {
        Debug.Log("CheckIfShouldOpenDoor called");

        KeySpawner keySpawner = Object.FindFirstObjectByType<KeySpawner>();

        if (keySpawner == null)
        {
            Debug.LogError("KeySpawner not in the scene!");
            return;
        }

        int totalKeys = keySpawner.GetTotalKeyCount();
        int collected = keySpawner.GetCollectedKeyCount();

        Debug.Log($"Keys collected: {collected} / {totalKeys}");

        if (collected >= totalKeys)
        {
            OpenDoor();
        }
    }



    private void OpenDoor()
    {
        
        spriteRenderer.sprite = openDoorSprite;

        Collider2D doorCollider = GetComponent<Collider2D>();
        if (doorCollider != null)
        {
            doorCollider.isTrigger = true;
        }

        Events.AnnounceUpdate?.Invoke("The door is now open. Escape quickly!");
    }
}

