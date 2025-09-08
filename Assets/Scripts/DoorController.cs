using System;
using TMPro;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Sprite openDoorSprite;
    [SerializeField] private GameObject winScreenUI;
    [SerializeField] private TextMeshProUGUI winScreenTimerText;
    [SerializeField] private GameObject announcerUI;
    SpriteRenderer spriteRenderer;
    BoxCollider2D doorCollider;
    DateTime startTime;
    private void Start()
    {
        startTime = DateTime.Now;
        spriteRenderer = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<BoxCollider2D>();
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
        if (doorCollider != null)
        {
            doorCollider.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            announcerUI.gameObject.SetActive(false);
            winScreenUI.SetActive(true);
            winScreenTimerText.text = $"Time Took: {(DateTime.Now - startTime).ToString(@"hh\:mm\:ss")}";
            Time.timeScale = 0;
        }
    }
}

