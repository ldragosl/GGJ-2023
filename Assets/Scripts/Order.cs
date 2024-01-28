using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private static int idCounter = 0;
    public int orderId;
    public string orderName;
    public float timeLeft = 10f;
    public NobleBehavior orderPlacer;
    public Order()
    {
        orderId = idCounter;
        idCounter++;
    }

    public virtual void fulfill()
    {

    }

    public virtual void discard()
    {

    }
}
