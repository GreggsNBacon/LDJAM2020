using System.Collections;
using UnityEngine;

namespace LudumDare.Core.EventManager
{
    public class TestEventManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            //EventManager<Events>.RegisterEvent(Events.GameStart, TriggerEventTester);
        }

        // Update is called once per frame
        void Start()
        {
            StartCoroutine(enumerator());
        }

        IEnumerator enumerator()
        {
            float duration = 5.0f;
            for (int i = 0; i < 6; i++)
            {
                float timer = 0.0f;
                while (timer < duration)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }
                //EventManager<Events>.TriggerEvent(Events.GameStart, Random.Range(0, 20), "random string lol", Random.Range(0, 20), "second random string lol");
            }
        }

        public void TriggerEventTester(Events eventName, object[] objects)
        {
            string strings = "";
            for (int i = 0; i < objects.Length; i++)
            {
                if (i != 0)
                {
                    strings += " ,";
                }
                strings += objects[i].ToString();
            }
            Debug.Log("Test Event Manager - Random Number: " + strings);
        }
    }
}