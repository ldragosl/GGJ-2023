using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : PickupableObject
{
    GrabObjects grabObjects;
    // Start is called before the first frame update


    void Awake()
    {
        
        grabObjects = GrabObjects.singleton; 
    }

    public override void OnPickup()
    {
        base.OnPickup();
    }

    public override void Drop()
    {

        base.Drop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
