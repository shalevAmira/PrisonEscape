using UnityEngine;

public enum DetectorType
{
    Guard,
    Camera
}

public class Detector : MonoBehaviour
{
    [SerializeField] private DetectorType detectorType;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string detectorName = detectorType.ToString(); 
            Events.OnPlayerDetected?.Invoke(detectorName);
            Events.AnnounceUpdateWithColor?.Invoke(
                $"You have been caught by {detectorName}! Hold R to restart.", Color.red
            );
        }
    }
}
