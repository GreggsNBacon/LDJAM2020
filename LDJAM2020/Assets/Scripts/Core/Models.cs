using System;
using System.Collections.Generic;
using LudumDare.Model;

namespace LudumDare.Core
{
    public static class Models
    {
        private static CarModel m_carModel { get; set; } = new CarModel();
        private static GameModel m_gameModel { get; set; } = new GameModel();

        private static Dictionary<Type, object> m_models = new Dictionary<Type, object>();

        public static void InitialiseModels()
        {
            m_carModel = new CarModel();
            m_gameModel = new GameModel();

            m_models.Add(typeof(CarModel), m_carModel);
            m_models.Add(typeof(GameModel), m_gameModel);
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
        }

        public static T GetModel<T>() where T : IModel
        {
            return (T) m_models[typeof(T)];
        }

        public interface IModel
        {
        }
    }
}