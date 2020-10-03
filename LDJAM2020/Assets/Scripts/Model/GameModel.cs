using System;

namespace LudumDare.Model
{
    public class GameModel : AbstractModel
    {
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
    }
}