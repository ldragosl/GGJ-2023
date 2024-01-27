using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour
{
    public Transform hand;
    void Start()
    {
        
    }

    public virtual void OnPickup()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.position = hand.position;
        gameObject.transform.rotation = Quaternion.Euler(-90, 0, 180);
        gameObject.transform.parent = hand;
        gameObject.GetComponent<Collider>().enabled = false;
    }

    public virtual void Drop()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.parent = null;
        gameObject.GetComponent<Collider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
