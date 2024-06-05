using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsData
{
    public const string VOLUME_PREF = "volume";
    public const string MOUSE_PREF = "invertedMouse";

    public const int VOLUME_DEFAULT = 10;
    public const bool MOUSE_DEFAULT = false;

    public static int volume = VOLUME_DEFAULT;
    public static bool invertedMouse = MOUSE_DEFAULT;

    public static void Load()
    {
        volume = PlayerPrefs.GetInt(VOLUME_PREF, VOLUME_DEFAULT);
        invertedMouse = PlayerPrefs.GetInt(MOUSE_PREF, MOUSE_DEFAULT ? 1 : 0) == 1;
    }

    public static void BumpVolume()
    {
        volume++;
        PlayerPrefs.SetInt(VOLUME_PREF, volume);
    }

    public static void ChangeInvertedMouse(bool value)
    {
        invertedMouse = value;
        PlayerPrefs.SetInt(MOUSE_PREF, invertedMouse ? 1 : 0);
    }

    public static void ChangeInvertedMouse()
    {
        ChangeInvertedMouse(!invertedMouse);
    }
}
