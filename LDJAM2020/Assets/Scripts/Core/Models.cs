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
            m_models.Add(typeof(CarModel), m_carModel);
            m_models.Add(typeof(GameModel), m_gameModel);
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