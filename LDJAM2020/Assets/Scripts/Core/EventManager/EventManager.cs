using System;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare.Core.EventManager
{
    public static class EventManager<T>
    {
        static Dictionary<T, List<Action<T, object[]>>> TDictionary = new Dictionary<T, List<Action<T, object[]>>>();
        public static void RegisterEvent(T eventName, Action<T, object[]> action)
        {
            if (TDictionary.ContainsKey(eventName))
            {
                TDictionary[eventName].Add(action);
            }
            else
            {
                List<Action<T, object[]>> list = new List<Action<T, object[]>>();
                list.Add(action);
                TDictionary.Add(eventName, list);
            }
        }

        public static void DeregisterEvent(T eventName, Action<T, object[]> action)
        {
            if (TDictionary.ContainsKey(eventName))
            {
                if (TDictionary[eventName].Contains(action))
                {
                    TDictionary[eventName].Remove(action);
                }
                else
                {
                    Debug.Log("EventManager - " + action.ToString() + " not found in list.");
                }
            }
            else
            {
                Debug.Log("EventManager - " + eventName.ToString() + " not found in dictionary.");
            }
        }

        public static void TriggerEvent(T eventName, params object[] objects)
        {
            if (TDictionary.ContainsKey(eventName))
            {
                foreach (Action<T, object[]> action in TDictionary[eventName])
                {
                    action(eventName, objects);
                }
            }
            else
            {
                Debug.Log("EventManager - " + eventName.ToString() + " not found in dictionary.");
            }
        }
    }
}