using System;
using UnityEngine;

namespace LudumDare.Model
{
    public class GameModel : AbstractModel
    {
        public class PositionalData
        {
            public PositionalData(Vector3 position, Vector3 rotation)
            {
                this.position = position;
                this.rotation = rotation;
            }
            Vector3 position;
            Vector3 rotation;
            public PositionalData next = null;

            public Vector3 Position { get => position;}
            public Vector3 Rotation { get => rotation; }
        }

        public PositionalData first = null;
        PositionalData last = null;

        public void AddToList(Vector3 position, Vector3 rotation)
        {
            PositionalData newData = new PositionalData(position, rotation);
            if (first == null)
            {
                first = newData;
                last = newData;
            }
            else
            {
                last.next = newData;
                last = newData;
            }
            OnPositionUpdated?.Invoke(position);
        }
        private int m_lap = 1;

        public int lap
        {
            get => m_lap;

            set
            {
                m_lap = value;
                OnLapUpdated?.Invoke(m_lap);
            }
        }

        public event Action<int> OnLapUpdated;

        public event Action<Vector3> OnPositionUpdated;

        private string m_level = "";

        public string level
        {
            get => m_level;

            set
            {
                m_level = value;
                OnLevelUpdated?.Invoke(m_lap);
            }
        }

        public event Action<int> OnLevelUpdated;
    }
}