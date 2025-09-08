using UnityEngine;

public class GuardController : MonoBehaviour
{
    [SerializeField] RangeInt range;
    [SerializeField] float timeToFlip = 5f;

    void Start()
    {
        InvokeRepeating(nameof(Flip), Random.Range(range.start, range.end), timeToFlip);
    }

    void Flip()
    {
        int numToFlipSprite = -1;
        Vector3 newScale = transform.localScale;
        newScale.x *= numToFlipSprite;
        transform.localScale = newScale;
    }
}
