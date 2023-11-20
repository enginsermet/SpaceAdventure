using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    public Button easyBtn, mediumBtn, hardBtn;
    // Start is called before the first frame update
    void Start()
    {
        if (Preferences.GetEasyValue() == 1)
        {
            easyBtn.interactable = false;
            mediumBtn.interactable = true;
            hardBtn.interactable = true;
        }
        else if (Preferences.GetMediumValue() == 1)
        {
            easyBtn.interactable = true;
            mediumBtn.interactable = false;
            hardBtn.interactable = true;
        }
        else if (Preferences.GetHardValue() == 1)
        {
            easyBtn.interactable = true;
            mediumBtn.interactable = true;
            hardBtn.interactable = false;
        }
    }

    public void SelectDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                Preferences.SetEasyValue(1);
                Preferences.SetMediumValue(0);
                Preferences.SetHardValue(0);
                easyBtn.interactable = false;
                mediumBtn.interactable = true;
                hardBtn.interactable = true;
                break;
            case "medium":
                Preferences.SetEasyValue(0);
                Preferences.SetMediumValue(1);
                Preferences.SetHardValue(0);
                easyBtn.interactable = true;
                mediumBtn.interactable = false;
                hardBtn.interactable = true;
                break;
            case "hard":
                Preferences.SetEasyValue(0);
                Preferences.SetMediumValue(0);
                Preferences.SetHardValue(1);
                easyBtn.interactable = true;
                mediumBtn.interactable = true;
                hardBtn.interactable = false;
                break;
            default:
                break;
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
