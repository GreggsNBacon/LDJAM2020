using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArtificialDownforce : MonoBehaviour
{
    [SerializeField]
    private float downforce;

    [SerializeField]
    private Transform downforcePos;
    [SerializeField]
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 force = -downforce * rb.transform.up;
        Debug.Log(force);
        rb.AddForceAtPosition(force, downforcePos.position);
    }
}
