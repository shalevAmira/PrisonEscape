using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveDistance = 2f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private bool moveVertically = false;
    [SerializeField] private float positionThreshold = 0.1f;

    private Vector3 startPosition;
    private bool movingPositive = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        PatrolMovement();
    }

    private void PatrolMovement()
    {
        float move = moveSpeed * Time.deltaTime;
        Vector3 direction = moveVertically ? Vector3.down : Vector3.up;

        if (movingPositive)
        {
            transform.position += direction * move;
            if (Vector3.Distance(transform.position, startPosition) >= moveDistance)
                movingPositive = false;
        }
        else
        {
            transform.position -= direction * move;
            if (Vector3.Distance(transform.position, startPosition) <= positionThreshold)
                movingPositive = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected by camera!");
            Events.OnPlayerDetected?.Invoke("SecurityCamera");
        }
    }
}
