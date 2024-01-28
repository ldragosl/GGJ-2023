using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour
{
    [SerializeField] Transform hand;
    GrabObjects grabObject;
    public bool isPicked = false;
    public bool isGenerator = false;
    public void Start()
    {
        hand = GameObject.FindGameObjectWithTag("Hand").transform;
        grabObject = GrabObjects.singleton;
    }

    void GenerateNew()
    {
        
        if (isGenerator)
        {
            GameObject inst = Instantiate(gameObject, transform.position, transform.rotation);
            isGenerator = false;
        }
    }

    public virtual void OnPickup()
    {
        
        if(!isGenerator)
        {
            GenerateNew();
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = hand.position;
            transform.rotation = Quaternion.Euler(-90, 0, 180);
            transform.parent = hand;
            GetComponent<Collider>().enabled = false;
            isPicked = true;
        }
        
        

    }

    public virtual void Drop()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
        GetComponent<Collider>().enabled = true;
        isPicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
