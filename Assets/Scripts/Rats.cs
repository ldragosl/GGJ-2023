using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rats : MonoBehaviour
{
    public Vector3 target;
    public float ratSpeed = 5f;
    public float targetY = 0.2f;
    public float targetZMin = -3.8f;
    public float targetZMax = 1.1f;
    public float targetXMin = -2.8f;
    public float targetXMax = 4.4f;

    private float initialHeight;
    // Start is called before the first frame update
    void Start()
    {
        setRandomTarget();
    }

    void setRandomTarget()
    {
        target = new Vector3(Random.Range(targetXMin, targetXMax), targetY, Random.Range(targetZMin, targetZMax));
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.position += transform.forward * ratSpeed * Time.deltaTime;
        if(Vector3.Distance(transform.position, target) < 0.1f)
        {
            setRandomTarget();
        }
    }
}
