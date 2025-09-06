using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] string detectorName = "Guard";

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Events.OnPlayerDetected?.Invoke(detectorName);
        }
    }
}
