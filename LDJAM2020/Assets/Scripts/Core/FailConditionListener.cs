using LudumDare.Core.EventManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailConditionListener : MonoBehaviour
{
    [SerializeField] private float delaySecs = 3.0f;

    private bool endGameStarted = false;
    private float timer = 0.0f;
    
    private void Awake()
    {
        EventManager<Events>.RegisterEvent(Events.FailConditionMet, FailConditionMet);
    }

    private void FailConditionMet(Events arg1, object[] arg2)
    {
        endGameStarted = true;
    }

    private void Update()
    {
        if (endGameStarted == true)
        {
            timer += Time.deltaTime;

            if (timer >= delaySecs)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }

    private void OnDestroy()
    {
        EventManager<Events>.DeregisterEvent(Events.FailConditionMet, FailConditionMet);
    }
}
