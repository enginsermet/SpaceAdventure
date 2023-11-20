using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Preferences
{
    public static string easy = "easy";
    public static string medium = "medium";
    public static string hard = "hard";

    public static string easyScore = "easyScore";
    public static string mediumScore = "mediumScore";
    public static string hardScore = "hardScore";

    public static string easyGold = "easyGold";
    public static string mediumGold = "mediumGold";
    public static string hardGold = "hardGold";


    public static string musicOn = "musicOn";

    public static void SetEasyValue(int easy)
    {
        PlayerPrefs.SetInt(Preferences.easy, easy);
    }

    public static int GetEasyValue()
    {
        return PlayerPrefs.GetInt(Preferences.easy);
    }

    public static void SetMediumValue(int medium)
    {
        PlayerPrefs.SetInt(Preferences.medium, medium);
    }
    public static int GetMediumValue()
    {
        return PlayerPrefs.GetInt(Preferences.medium);
    }

    public static void SetHardValue(int hard)
    {
        PlayerPrefs.SetInt(Preferences.hard, hard);
    }
    public static int GetHardValue()
    {
        return PlayerPrefs.GetInt(Preferences.hard);
    }


    public static void SetEasyScoreValue(int easyScore)
    {
        PlayerPrefs.SetInt(Preferences.easyScore, easyScore);
    }

    public static int GetEasyScoreValue()
    {
        return PlayerPrefs.GetInt(Preferences.easyScore);
    }

    public static void SetMediumScoreValue(int mediumScore)
    {
        PlayerPrefs.SetInt(Preferences.mediumScore, mediumScore);
    }
    public static int GetMediumScoreValue()
    {
        return PlayerPrefs.GetInt(Preferences.mediumScore);
    }

    public static void SetHardScoreValue(int hardScore)
    {
        PlayerPrefs.SetInt(Preferences.hardScore, hardScore);
    }
    public static int GetHardScoreValue()
    {
        return PlayerPrefs.GetInt(Preferences.hardScore);
    }



    public static void SetEasyGoldValue(int easyGold)
    {
        PlayerPrefs.SetInt(Preferences.easyGold, easyGold);
    }

    public static int GetEasyGoldValue()
    {
        return PlayerPrefs.GetInt(Preferences.easyGold);
    }

    public static void SetMediumGoldValue(int mediumGold)
    {
        PlayerPrefs.SetInt(Preferences.medium, mediumGold);
    }
    public static int GetMediumGoldValue()
    {
        return PlayerPrefs.GetInt(Preferences.mediumGold);
    }

    public static void SetHardGoldValue(int hardGold)
    {
        PlayerPrefs.SetInt(Preferences.hardGold, hardGold);
    }
    public static int GetHardGoldValue()
    {
        return PlayerPrefs.GetInt(Preferences.hardGold);
    }


    public static void SetMusicOnValue(int musicOn)
    {
        PlayerPrefs.SetInt(Preferences.musicOn, musicOn);
    }
    public static int GetMusicOnValue()
    {
        return PlayerPrefs.GetInt(Preferences.musicOn);
    }


    public static bool PrefSaved()
    {
        if (PlayerPrefs.HasKey(Preferences.easy) ||
            PlayerPrefs.HasKey(Preferences.medium) ||
            PlayerPrefs.HasKey(Preferences.hard))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool MusicOnPref()
    {
        if (PlayerPrefs.HasKey(Preferences.musicOn))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
