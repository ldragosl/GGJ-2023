using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pan : PickupableObject
{
    public float LastPickedupTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnPickup()
    {
        base.Start();
        base.OnPickup();

        GameObject[] rats = GameObject.FindGameObjectsWithTag("Rat");
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        transform.eulerAngles = new Vector3(-90f, 0f, 180f);
        foreach (GameObject rat in rats)
        {
            Rats ratComp = rat.GetComponent<Rats>();
            if (ratComp != null)
            {
                ratComp.retakePan();
            }
        }
    }

    public override void Drop()
    {
        base.Drop();

        LastPickedupTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
