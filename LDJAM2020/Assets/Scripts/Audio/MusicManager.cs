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

    private GameModel gameModel;

    private bool lapComplete = true;

    private float currentTime;
    private int currentLap = 1;

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
        timer -= Time.deltaTime;
        if(currentTime <= 0.0f)
        {
            timer = currentTime;
            if (lapComplete)
            {
                lapComplete = false;
                ProcessClips();
            }
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
            if(clips[i].maxLap != 0 && clips[i].maxLap <= currentLap)
            {
                clips[i].clip.Stop();
            }
            else if(clips[i].minLap <= currentLap)
            {
                clips[i].clip.Play();
            }
        }
    }
}
