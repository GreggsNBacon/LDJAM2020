using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float refreshTime = 3.0f;
    private float currentTime = 0.0f;

    Quaternion desiredRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            currentTime = refreshTime;
            transform.rotation = Quaternion.Euler(Random.Range(-20, 20), Random.Range(-45, 45), Random.Range(-10, 10));
        }
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
