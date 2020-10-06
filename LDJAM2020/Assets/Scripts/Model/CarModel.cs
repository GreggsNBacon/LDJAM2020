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
        private float m_fallSpeed = 2.0f;
        private float m_minGroundDistance = 0.1f;
        private float m_turning = 0.0f;
        private float m_throttle = 0.0f;
        private float m_mphPerUnit = 0.0f;
        private float m_maxAchievedSpeed = 0.0f;

        public float maxAchievedSpeed
        {
            get => m_maxAchievedSpeed;
        }
        public float currentSpeed
        {
            get => m_currentSpeed;

            set
            {
                m_currentSpeed = value;
                if(m_currentSpeed >= m_maxAchievedSpeed)
                {
                    m_maxAchievedSpeed = m_currentSpeed;
                }
                OnCurrentSpeedUpdated?.Invoke(m_currentSpeed);
            }
        }
        public event Action<float> OnCurrentSpeedUpdated;

        public float mphPerUnit
        {
            get => m_mphPerUnit;

            set
            {
                m_mphPerUnit = value;
                OnMphPerUnitUpdated?.Invoke(m_mphPerUnit);
            }
        }
        public event Action<float> OnMphPerUnitUpdated;

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

        public float fallSpeed
        {
            get => m_fallSpeed;

            set
            {
                m_fallSpeed = value;
                OnFallSpeedUpdated?.Invoke(m_fallSpeed);
            }
        }
        public event Action<float> OnFallSpeedUpdated;

        public float minGroundDistance
        {
            get => m_minGroundDistance;

            set
            {
                m_minGroundDistance = value;
                OnMinGroundDistanceUpdated?.Invoke(m_minGroundDistance);
            }
        }
        public event Action<float> OnMinGroundDistanceUpdated;

        public float turning
        {
            get => m_turning;

            set
            {
                m_turning = value;
                OnTurningUpdated?.Invoke(m_turning);
            }
        }
        public event Action<float> OnTurningUpdated;

        public float throttle
        {
            get => m_turning;

            set
            {
                m_turning = value;
                OnThrottleUpdated?.Invoke(m_turning);
            }
        }
        public event Action<float> OnThrottleUpdated;
    }
}