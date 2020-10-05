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
    private float currentDelay = 0.0f;
    private float currentStopDelay = 0.0f;

    private bool played = false;
    private bool play = false;

    private bool fadeIn = false;

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
                if (Source.volume <= 1.0f)
                {
                    Source.volume += fadeSpeed * Time.deltaTime;
                    Source.volume = Mathf.Clamp(Source.volume, 0, 1);
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
                stop = false;
                Source.volume = 0;
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
