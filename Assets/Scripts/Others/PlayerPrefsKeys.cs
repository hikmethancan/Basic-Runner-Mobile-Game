using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsKeys
{
    public static int CurrentLevel
    {
        get => PlayerPrefs.GetInt("CurrentLevel", 1);
        set => PlayerPrefs.SetInt("CurrentLevel", value);
    }
    
    public static int StackAmount
    {
        get => PlayerPrefs.GetInt("CurrentstackAmount", 0);
        set => PlayerPrefs.SetInt("CurrentstackAmount", value);
    }

    public static int MaxStackAmount
    {
        get => PlayerPrefs.GetInt("MaxStackAmount", 10);
        set => PlayerPrefs.SetInt("MaxStackAmount", value);
    }

    public static int GoldAmount
    {
        get => PlayerPrefs.GetInt("CurrencyAmount", 0);
        set => PlayerPrefs.SetInt("CurrencyAmount", value);
    }

}
