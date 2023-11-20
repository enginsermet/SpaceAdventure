using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    Sprite[] musicIcons = default;

    [SerializeField]
    Button musicBtn = default;



    // Start is called before the first frame update
    void Start()
    {
        if (Preferences.PrefSaved() == false)
        {
            Preferences.SetEasyValue(1);
        }
        if (Preferences.MusicOnPref() == false)
        {
            Preferences.SetMusicOnValue(1);
        }
        MusicSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Scoreboard()
    {
        SceneManager.LoadScene("Scoreboard");
    }

    public void Music()
    {
        if(Preferences.GetMusicOnValue() == 1)
        {
            Preferences.SetMusicOnValue(0);
            MusicControl.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }
        else
        {
            Preferences.SetMusicOnValue(1);
            MusicControl.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        }
    }

    void MusicSettings()
    {
        if (Preferences.GetMusicOnValue() == 1)
        {
            musicBtn.image.sprite = musicIcons[1];
            MusicControl.instance.PlayMusic(true);
        }
        else
        {
            musicBtn.image.sprite = musicIcons[0];
            MusicControl.instance.PlayMusic(false);
        }
    }
}
