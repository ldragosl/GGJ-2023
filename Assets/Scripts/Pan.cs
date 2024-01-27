using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pan : PickupableObject
{
    public float LastPickedupTime;
    CookableMeat meat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnPickup()
    {
        base.OnPickup();
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
