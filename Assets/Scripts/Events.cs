using System;
using UnityEngine;

public static class Events
{
    public static Action<string> OnPlayerDetected;
    public static Action<string> AnnounceUpdate;
    public static Action<string, Color> AnnounceUpdateWithColor;
    public static Action OnKeyCollected;
}
