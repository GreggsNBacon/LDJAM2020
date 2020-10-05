using LudumDare.Core;
using LudumDare.Model;
using UnityEngine;

namespace LudumDare.Controller
{
    public class AudioController : AbstractController
    {
        [SerializeField] private AudioClip[] soundClips = null;
        [SerializeField] private AudioClip[] musicClips = null;

        private AudioModel audioModel = null;

        protected override void Awake()
        {
            audioModel = Models.GetModel<AudioModel>();

            if (audioModel != null)
            {
                for (int i = 0; i < soundClips.Length; ++i)
                {
                    audioModel.AddSound(soundClips[i].name, soundClips[i]);
                }

                for (int i = 0; i < musicClips.Length; ++i)
                {
                    audioModel.AddMusic(musicClips[i].name, musicClips[i]);
                }
            }
        }
    }
}