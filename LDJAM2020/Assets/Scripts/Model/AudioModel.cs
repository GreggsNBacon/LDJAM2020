using System.Collections.Generic;
using UnityEngine;

namespace LudumDare.Model
{
    public class AudioModel : AbstractModel
    {
        private Dictionary<string, AudioClip> m_sounds = new Dictionary<string, AudioClip>();
        private Dictionary<string, AudioClip> m_music = new Dictionary<string, AudioClip>();

        public void AddSound(string name, AudioClip clip)
        {
            m_sounds.Add(name, clip);
        }

        public void AddMusic(string name, AudioClip clip)
        {
            m_music.Add(name, clip);
        }

        public AudioClip GetSound(string name)
        {
            if (m_sounds.ContainsKey(name))
            {
                return m_sounds[name];
            }
            else
            {
                Debug.LogWarning("Can't find audio clip - " + name);
                return null;
            }
        }

        public AudioClip GetMusic(string name)
        {
            if (m_music.ContainsKey(name))
            {
                return m_music[name];
            }
            else
            {
                Debug.LogWarning("Can't find audio clip - " + name);
                return null;
            }
        }
    }
}