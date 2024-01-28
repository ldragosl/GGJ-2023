using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightSrc;
    public float minRange = 3f;
    public float maxRange = 12f;

    public float minTime = 2f;
    public float maxTime = 5f;

    public float t = 0f;
    float flickerSpeed = 1f;

    private float rangeTargetCurrent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void EstablishRandomFlicker()
    {
        rangeTargetCurrent = Random.Range(minRange, maxRange);
        flickerSpeed = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(t > 1f)
        {
            EstablishRandomFlicker();
            t = 0f;
        }
        t += Time.deltaTime * flickerSpeed;
        lightSrc.range = Mathf.Lerp(lightSrc.range, rangeTargetCurrent, t);
    }
}
