using System;
using TMPro;
using UnityEngine;

public class Announcer : MonoBehaviour
{
    TextMeshProUGUI announcementText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        announcementText = GetComponent<TextMeshProUGUI>();
        Events.OnAnnounceUpdate += Announce;
    }

    private void Announce(string message)
    {
        announcementText.text = message;
    }

    private void OnDestroy()
    {
        Events.OnAnnounceUpdate -= Announce;
    }
}
