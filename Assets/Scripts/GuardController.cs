using UnityEngine;

public class GuardController : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating(nameof(Flip), 5f, 5f);
    }

    void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
