using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private bool isdone = false;

    public AudioSource ButtonPress;
    public AudioSource RunAbility;
    public AudioSource BackgroundMusic;
    public AudioSource RoundWin;
    public AudioSource RoundLose;

    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        StopBackMusic();
    }

    public void ButtonPressSound()
    {
        ButtonPress.Play();
    }

    public void RunAbilitySound()
    {
        RunAbility.Play();
    }

    void StopBackMusic()
    {
        
        GameObject Player = GameObject.Find("Player");
        PlayerController pc = Player.GetComponent<PlayerController>();
        if(pc.GCoinCount == 5 && !isdone)
        {
            BackgroundMusic.Stop();
            RoundWin.Play();
            isdone = true;
        }

        else if(pc.TimeLeft == 0 && !isdone)
        {
            BackgroundMusic.Stop();
            RoundLose.Play();
            isdone = true;
        }

        
    }

    
}
