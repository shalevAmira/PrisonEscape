using UnityEngine;

public class CollectableKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Events.OnKeyCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
