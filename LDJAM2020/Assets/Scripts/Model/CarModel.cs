using System;

namespace LudumDare.Model
{
    public class CarModel : AbstractModel
    {
        private float m_currentSpeed = 5.0f;
        private float m_maxSpeed = 14.0f;
        private float m_minSpeed = 5.0f;
        private float m_minSpeedDelta = 0.5f;
        private float m_maxBoost = 10.0f;
        private float m_rotationSpeed = 10.0f;

        public float currentSpeed
        {
            get => m_currentSpeed;

            set
            {
                m_currentSpeed = value;
                OnCurrentSpeedUpdated?.Invoke(m_currentSpeed);
            }
        }
        public event Action<float> OnCurrentSpeedUpdated;

        public float maxSpeed
        {
            get => m_maxSpeed;

            set
            {
                m_maxSpeed = value;
                OnMaxSpeedUpdated?.Invoke(m_maxSpeed);
            }
        }
        public event Action<float> OnMaxSpeedUpdated;

        public float minSpeed
        {
            get => m_minSpeed;

            set
            {
                m_minSpeed = value;
                OnMinSpeedUpdated?.Invoke(m_minSpeed);
            }
        }
        public event Action<float> OnMinSpeedUpdated; 

        public float minSpeedDelta
        {
            get => m_minSpeedDelta;

            set
            {
                m_minSpeed = value;
                OnMinSpeedDeltaUpdated?.Invoke(m_minSpeedDelta);
            }
        }
        public event Action<float> OnMinSpeedDeltaUpdated;

        public float maxBoost
        {
            get => m_maxBoost;

            set
            {
                m_maxBoost = value;
                OnMaxBoostUpdated?.Invoke(m_maxBoost);
            }
        }
        public event Action<float> OnMaxBoostUpdated;

        public float rotationSpeed
        {
            get => m_rotationSpeed;

            set
            {
                m_rotationSpeed = value;
                OnRotationSpeedUpdated?.Invoke(m_rotationSpeed);
            }
        }
        public event Action<float> OnRotationSpeedUpdated;
    }
}