using System;
using TMPro;
using UnityEngine;

public class Announcer : MonoBehaviour
{
    TextMeshProUGUI announcementText;
    private void Awake()
    {
        announcementText = GetComponent<TextMeshProUGUI>();
        Events.AnnounceUpdate += Announce;
        Events.AnnounceUpdateWithColor += AnnounceWithColor;
    }

    private void Announce(string message)
    {
        announcementText.color = Color.white;
        announcementText.text = message;
    }

    private void AnnounceWithColor(string message, Color color)
    {
        announcementText.color = color;
        announcementText.text = message;
    }

    private void OnDestroy()
    {
        Events.AnnounceUpdate -= Announce;
        Events.AnnounceUpdateWithColor -= AnnounceWithColor;
    }
}
