using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] string detectorName = "Guard";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Events.OnPlayerDetected?.Invoke(detectorName);
            Events.AnnounceUpdateWithColor?.Invoke(
                $"You have been cought by {detectorName}! Hold R to restart.", Color.red
            );
        }
    }
}
