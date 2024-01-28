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
    private float stolePanTime = 0f;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        setRandomTarget();
    }

    public void retakePan()
    {
        if (stolePan == true)
        {
            GameObject.FindGameObjectWithTag("KingUI").GetComponent<KingBehaviour>().AddLaughter(10);
        }
            stolePan = false;
        timeToSteal = Random.Range(3f, 6f);
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

        if (stolePan && Time.time - stolePanTime > 2f )
        {
            target.y = targetY;
            panComp.transform.position = transform.position + new Vector3(0f, 0.3f, 0f);
            panComp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        transform.LookAt(target);
        transform.position += transform.forward * ratSpeed * Time.deltaTime;
        if(Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (wantsToStealPan)
            {
                wantsToStealPan = false;
                stolePan = true;
                stolePanTime = Time.time;
                panComp.transform.position = transform.position + new Vector3(0f, 0.3f, 0f);
                panComp.gameObject.transform.parent = transform;
            }
            else setRandomTarget();
        }
    }
}
