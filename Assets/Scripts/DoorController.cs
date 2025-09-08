using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Sprite openDoorSprite;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Events.OpenDoor += OpenDoor;
    }

    private void OnDisable()
    {
        Events.OpenDoor -= OpenDoor;
    }

    private void OpenDoor()
    {
        spriteRenderer.sprite = openDoorSprite;
        Collider2D doorCollider = GetComponent<Collider2D>();
        if (doorCollider != null)
        {
            doorCollider.isTrigger = true;
        }
    }
}

