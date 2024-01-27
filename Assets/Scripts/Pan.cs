using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pan : PickupableObject
{
    float LastPickedupTime;
    CookableMeat meat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnPickup()
    {
        base.OnPickup();

        LastPickedupTime = Time.time;
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
