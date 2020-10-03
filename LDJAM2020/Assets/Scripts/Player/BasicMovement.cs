using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private float minSpeed = 1.0f;
    private float boost = 1.0f;
    private float desiredValue = 0.0f;
    [SerializeField]
    private float maxBoost = 10.0f;
    [SerializeField]
    private float maxTurn = 10.0f;
    private float turning = 0.0f;


    // Update is called once per frame
    void Update()
    {
        UpdateThrottle();
        transform.position += transform.forward * (minSpeed * Time.deltaTime);
        transform.position += transform.forward * (boost * maxBoost * Time.deltaTime);
        transform.position += transform.right * (turning * Time.deltaTime);
    }

    void UpdateThrottle()
    {
        if(boost < desiredValue)
        {
            boost += Time.deltaTime;
        }
        else if (boost > desiredValue)
        {
            boost -= Time.deltaTime;
        }
    }

    public void Throttle(float desired)
    {
        desiredValue = desired;
        desiredValue = Mathf.Clamp(desiredValue, 0, 1);
    }

    public void Turn(float turn)
    {
        turning = turn;
    }
}
