using UnityEngine;

public class GuardController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        InvokeRepeating(nameof(Flip), 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
