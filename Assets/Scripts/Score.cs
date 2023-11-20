using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;

    int highestScore = 0;

    int highestGoldScore = 0;

    int goldCount;

    bool gameOver = false;

    [SerializeField]
    TMP_Text scoreText = default;

    [SerializeField]
    TMP_Text goldText = default;

    [SerializeField]
    TMP_Text finalScoreText = default;

    [SerializeField]
    TMP_Text finalGoldText = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            score = (int)Camera.main.transform.position.y;
            scoreText.text = "Score: " + score;

            goldText.text = "X " + goldCount;
        }
    }

    public void CollectGold()
    {
        FindObjectOfType<SoundControl>().Gold();
        goldCount++;
    }

    public void GameOver()
    {
        if (Preferences.GetEasyValue() == 1)
        {
            if (score > highestScore)
            {
                highestScore = score;
                if (goldCount > highestGoldScore)
                {
                    highestGoldScore = goldCount;
                }
                Preferences.SetEasyScoreValue(score);
                Preferences.SetEasyGoldValue(goldCount);
            }
        }

        if (Preferences.GetMediumValue() == 1)
        {
            if (score > highestScore)
            {
                highestScore = score;
                if (goldCount > highestGoldScore)
                {
                    highestGoldScore = goldCount;
                }
                Preferences.SetMediumScoreValue(score);
                Preferences.SetMediumGoldValue(goldCount);
            }
        }

        if (Preferences.GetHardValue() == 1)
        {
            if (score > highestScore)
            {
                highestScore = score;
                if (goldCount > highestGoldScore)
                {
                    highestGoldScore = goldCount;
                }
                Preferences.SetHardScoreValue(score);
                Preferences.SetHardGoldValue(goldCount);
            }
        }
        gameOver = true;
        finalScoreText.text = "Score: " + score;
        finalGoldText.text = "X " + goldCount;
    }
}
