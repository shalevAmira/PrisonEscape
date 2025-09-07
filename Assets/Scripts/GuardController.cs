using UnityEngine;

public class GuardController : MonoBehaviour
{
    

    void Start()
    {
        
        InvokeRepeating(nameof(Flip), UnityEngine.Random.Range(1, 5), 5f);
    }

    void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
