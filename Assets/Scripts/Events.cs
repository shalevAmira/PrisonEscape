using System;
using UnityEngine;

public static class Events
{
    public static Action<string> OnPlayerDetected;
    public static Action<string> OnAnnounceUpdate;
    public static Action<string, Color> OnAnnounceUpdateWithColor;
    public static Action OnKeyCollected;
}
