using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour
{
    public Transform hand;
<<<<<<< HEAD

=======
    public bool isPicked;
>>>>>>> 5705f299226ca7674514a5cc45de0b3e7e9527eb
    void Start()
    {

    }

    public virtual void OnPickup()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        transform.position = hand.position;
        transform.rotation = Quaternion.Euler(-90, 0, 180);
        transform.parent = hand;
        GetComponent<Collider>().enabled = false;
        isPicked = true;
    }

    public virtual void Drop()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
        GetComponent<Collider>().enabled = true;
        isPicked=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
