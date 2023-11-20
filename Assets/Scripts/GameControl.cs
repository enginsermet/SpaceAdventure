using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    public GameObject gameOverPanel;
    public GameObject joystick;
    public GameObject jumpBtn;
    public GameObject board;
    public GameObject menuBtn;
    public GameObject slider;

    SoundControl soundControl;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        UIOn();
        soundControl = GetComponent<SoundControl>();
    }

    public void GameOver()
    {
       FindObjectOfType<SoundControl>().GameOver();
       gameOverPanel.SetActive(true);
       FindObjectOfType<Score>().GameOver();
       FindObjectOfType<PlayerControl>().GameOver();
       UIOff();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

    void UIOn()
    {
        joystick.SetActive(true);
        jumpBtn.SetActive(true);
        board.SetActive(true);
        menuBtn.SetActive(true);
        slider.SetActive(true);
    }

    void UIOff()
    {
        joystick.SetActive(false);
        jumpBtn.SetActive(false);
        board.SetActive(false);
        menuBtn.SetActive(false);
        slider.SetActive(false);
    }
}
