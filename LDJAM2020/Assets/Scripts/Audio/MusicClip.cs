using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClip : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private float delay = 0.0f;

    [SerializeField]
    private float stopDelay = 0.0f;

    [SerializeField]
    private float fadeSpeed = 1.0f;

    [SerializeField]
    private bool playOnce = false;

    [SerializeField]
    private bool listenToVolume = false;
    [SerializeField]
    private float maxVolume = 0.6f;

    private float currentDelay = 0.0f;
    private float currentStopDelay = 0.0f;

    private bool played = false;
    private bool play = false;

    private bool fadeIn = false;
    private bool fadeOut = false;

    private bool stop = false;

    public bool ListenToVolume { get => listenToVolume; set => listenToVolume = value; }
    public AudioSource Source { get => source; set => source = value; }

    private void Update()
    {
        if (play)
        {
            if (!played)
            {
                currentDelay -= Time.deltaTime;
                if (currentDelay <= 0.0f)
                {
                    played = true;
                    fadeIn = true;
                }
            }
            
            if (fadeIn)
            {
                if (Source.volume <= maxVolume)
                {
                    Source.volume += fadeSpeed * Time.deltaTime;
                    Source.volume = Mathf.Clamp(Source.volume, 0, maxVolume);
                }
                else
                {
                    fadeIn = false;
                }
            }
        }

        if (stop)
        {
            currentStopDelay -= Time.deltaTime;
            if(currentStopDelay <= 0)
            {
                fadeOut = true;
                
            }
            if (fadeOut)
            {
                if (Source.volume >= 0.0f)
                {
                    Source.volume -= fadeSpeed * Time.deltaTime;
                    Source.volume = Mathf.Clamp(Source.volume, 0, maxVolume);
                }
                else
                {
                    fadeOut = false;
                    stop = false;
                    Source.volume = 0;
                }
            }
        }
    }

    public void Play()
    {
        if (playOnce)
        {
            Source.Play();
        }
        else
        {
            currentDelay = delay;
            play = true;
            played = false;
        }
        
    }

    public void Stop()
    {
        currentStopDelay = stopDelay;
        stop = true;
        play = false;
    }
}
