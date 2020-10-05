using System;
using System.Collections.Generic;
using LudumDare.Model;
using UnityEngine;

namespace LudumDare.Core
{
    public static class Models
    {
        private static Dictionary<Type, object> m_models = new Dictionary<Type, object>();

        public static void InitialiseModels()
        {
            m_models.Add(typeof(CarModel), new CarModel());
            m_models.Add(typeof(GameModel), new GameModel());
            m_models.Add(typeof(AudioModel), new AudioModel());
        }

        public static void ClearModels()
        {
            if (m_models.ContainsKey(typeof(CarModel)))
            {
                m_models.Remove(typeof(CarModel));
            }

            if (m_models.ContainsKey(typeof(GameModel)))
            {
                m_models.Remove(typeof(GameModel));
            }

            if (m_models.ContainsKey(typeof(AudioModel)))
            {
                m_models.Remove(typeof(AudioModel));
            }
        }

        public static T GetModel<T>() where T : IModel
        {
            if (m_models.ContainsKey(typeof(T)))
            {
                return (T)m_models[typeof(T)];
            }

            Debug.LogWarning("Error: cannot find model " + typeof(T) + " in dictionary");

            return default;
        }

        public interface IModel
        {
        }
    }
}