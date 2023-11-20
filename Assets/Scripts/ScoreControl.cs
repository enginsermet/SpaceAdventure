using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public TMP_Text easyScore, mediumScore, hardScore, easyGold, mediumGold, hardGold;
    // Start is called before the first frame update
    void Start()
    {
        easyScore.text = "Score: " + Preferences.GetEasyScoreValue();
        easyGold.text = "X " + Preferences.GetEasyGoldValue();

        mediumScore.text = "Score: " + Preferences.GetMediumScoreValue();
        mediumGold.text = "X " + Preferences.GetMediumGoldValue();

        hardScore.text = "Score: " + Preferences.GetHardScoreValue();
        hardGold.text = "X " + Preferences.GetHardGoldValue();
    }



    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
