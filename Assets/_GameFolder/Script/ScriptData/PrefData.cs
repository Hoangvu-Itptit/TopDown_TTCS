﻿using UnityEngine;

public class PrefData
{
    public static int player_type
    {
        get => PlayerPrefs.GetInt("player_type", 0);
        set => PlayerPrefs.SetInt("player_type", value);
    }

    public static int gun_type
    {
        get => PlayerPrefs.GetInt("gun_type", 0);
        set => PlayerPrefs.SetInt("gun_type", value);
    }

    public static bool IsHaveGun(int index)
    {
        return PlayerPrefs.GetInt($"gun_{index}", 0) == 1;
    }

    public static void SetHaveGun(int index)
    {
        PlayerPrefs.SetInt($"gun_{index}", 1);
    }

    public static bool IsHaveModel(int index)
    {
        return PlayerPrefs.GetInt($"model_{index}", 0) == 1;
    }

    public static void SetHaveModel(int index)
    {
        PlayerPrefs.SetInt($"model_{index}", 1);
    }
}