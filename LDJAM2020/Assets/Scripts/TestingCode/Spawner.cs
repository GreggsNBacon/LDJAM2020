using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawn;
    [SerializeField]
    private float timer = 3.0f;
    private float current = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        current = timer;
    }

    // Update is called once per frame
    void Update()
    {
        current -= Time.deltaTime;
        if(current <= 0.0f)
        {
            Instantiate(objectToSpawn);
            current = timer;
        }
    }
}
