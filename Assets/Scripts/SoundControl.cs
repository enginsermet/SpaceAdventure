using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField]
    AudioClip jump;
    [SerializeField]
    AudioClip gold;
    [SerializeField]
    AudioClip gameOver;


    // Start is called before the first frame update
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }

    public void Jump()
    {
        audioSource.PlayOneShot(jump);
    }

    public void Gold()
    {
        audioSource.PlayOneShot(gold);
    }

    public void GameOver()
    {
        audioSource.PlayOneShot(gameOver);
    }

}
