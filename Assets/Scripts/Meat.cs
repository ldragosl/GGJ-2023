using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : PickupableObject
{
    GrabObjects grabObjects;
    // Start is called before the first frame update
    void Start()
    {
        grabObjects = GrabObjects.singleton; 
    }

    public override void OnPickup()
    {
        base.OnPickup();
        grabObjects.isPicked = true;
    }

    public override void Drop()
    {
        base.Drop();
        grabObjects.isPicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
