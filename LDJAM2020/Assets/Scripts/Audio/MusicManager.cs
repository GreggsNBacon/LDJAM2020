using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LudumDare.Core;
using LudumDare.Model;

public class MusicManager : MonoBehaviour
{
    [Serializable]
    struct ClipDetails
    {
        public MusicClip clip;
        public int minLap;
        public int maxLap;
    }
    [SerializeField]
    private float timer = 4.0f;


    [SerializeField]
    ClipDetails[] clips;

    [Header("Normal Music")]

    [SerializeField]
    private int lapToSwitchToNormalMusic = 8;

    [SerializeField]
    private AudioSource normalSource = null;

    [SerializeField]
    private AudioClip[] normalMusicClips;

    private int currentMusicIndex = 0;

    private GameModel gameModel;

    private AudioClip currentMainClip;

    private bool lapComplete = true;

    private bool normalMusic = false;

    private float currentTime;
    private int currentLap = 1;

    private float normalMusicCounter;

    // Start is called before the first frame update
    void Start()
    {
        gameModel = Models.GetModel<GameModel>();
        gameModel.OnLapUpdated += LapComplete;
    }

    private void OnDestroy()
    {
        gameModel.OnLapUpdated -= LapComplete;
    }

    // Update is called once per frame
    void Update()
    {
        if (!normalMusic)
        {
            if (currentLap >= lapToSwitchToNormalMusic)
            {
                normalMusic = true;
            }
            timer -= Time.deltaTime;
            if (currentTime <= 0.0f)
            {
                timer = currentTime;
                if (lapComplete)
                {
                    lapComplete = false;
                    ProcessClips();
                }
            }
        }
        else
        {
            normalMusicCounter -= Time.deltaTime;
            if(normalMusicCounter <= 0)
            {
                SetNormalMusic();
            }
        }
    }

    private void SetNormalMusic()
    {
        if(normalMusicClips.Length >0 && currentMusicIndex < normalMusicClips.Length)
        {
            AudioClip newClip = normalMusicClips[currentMusicIndex];
            normalMusicCounter = newClip.length + 0.5f;
            normalSource.PlayOneShot(newClip);
            currentMainClip = newClip;
            currentMusicIndex++;
        }
    }

    private void LapComplete(int lap)
    {
        currentLap = lap;
        lapComplete = true;
    }

    private void ProcessClips()
    {

        for (int i = 0; i < clips.Length; i++)
        {
            if ((clips[i].maxLap != 0 && clips[i].maxLap <= currentLap) || currentLap >= lapToSwitchToNormalMusic)
            {
                if (currentMainClip == clips[i].clip.Source.clip)
                {
                    currentMainClip = null;
                }
                clips[i].clip.Stop();
            }
            else if (clips[i].minLap <= currentLap)
            {
                clips[i].clip.Play();
                if (currentMainClip == null)
                {
                    currentMainClip = clips[i].clip.Source.clip;
                }
                else if (clips[i].clip.ListenToVolume)
                {
                    currentMainClip = clips[i].clip.Source.clip;
                }
            }
        }

    }
}
