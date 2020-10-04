using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private float duration = 20.0f;

    [SerializeField]
    private RawImage rawImage = null;


    private float currentDuration = 0.0f;

    private bool animate = false;
    // Start is called before the first frame update
    void Start()
    {
        SetAlpha(0);
    }

    private void OnDestroy()
    {
    }

    public void TriggerFade()
    {
        animate = true;
        currentDuration = 0.0f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (animate)
        {
            currentDuration += Time.deltaTime;
            SetAlpha(curve.Evaluate(currentDuration / duration));
            if (currentDuration >= duration)
            {
                animate = false;
            }
        }
    }

    private void SetAlpha(float alpha)
    {
        Color col = rawImage.color;
        col.a = alpha;
        rawImage.color = col;
    }

    
}
