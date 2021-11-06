﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMainMenu : MonoBehaviour
{
    private bool isdone = false;

    public AudioSource ButtonPress;
    public AudioSource BackgroundMusic;
    

    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressSound()
    {
        ButtonPress.Play();
    }

}
