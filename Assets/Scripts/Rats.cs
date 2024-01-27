using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rats : MonoBehaviour
{
    public float timeToSteal = 5f;
    public float ratSpeedMin = 2f;
    public float ratSpeedMax = 6f;
    public float targetY = 0.2f;
    public float targetZMin = -3.8f;
    public float targetZMax = 1.1f;
    public float targetXMin = -2.8f;
    public float targetXMax = 4.4f;

    private float ratSpeed = 5f;
    private bool wantsToStealPan = false;
    private bool stolePan = false;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        setRandomTarget();
    }

    public void retakePan()
    {
        stolePan = true;
    }

    void setRandomTarget()
    {
        target = new Vector3(Random.Range(targetXMin, targetXMax), targetY, Random.Range(targetZMin, targetZMax));
        ratSpeed = Random.Range(ratSpeedMin, ratSpeedMax);
    }

    // Update is called once per frame
    void Update()
    {
        Pan panComp = GameObject.FindGameObjectWithTag("Pan").GetComponent<Pan>();
        if (!wantsToStealPan && !stolePan)
        {

            if (Time.time - panComp.LastPickedupTime > timeToSteal && !panComp.isPicked)
            {
                wantsToStealPan = true;
                target = panComp.transform.position;
                target.y = targetY;
            }
        }

        transform.LookAt(target);
        transform.position += transform.forward * ratSpeed * Time.deltaTime;
        if(Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (wantsToStealPan)
            {
                wantsToStealPan = false;
                stolePan = true;
                panComp.transform.position = transform.position + new Vector3(0f, 0.2f, 0f);
                panComp.gameObject.transform.parent = transform;
            }
            else setRandomTarget();
        }
    }
}
