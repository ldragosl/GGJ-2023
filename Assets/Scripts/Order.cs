using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private static int idCounter = 0;
    public bool fulfilled = false;
    public int orderId;
    public string orderName;
    public float timeLeft = 30f;
    public NobleBehavior orderPlacer;
    public Order()
    {
        orderId = idCounter;
        idCounter++;
    }

    public virtual void fulfill()
    {
        fulfilled = true;
        GameObject.FindGameObjectWithTag("ScoreUI").GetComponent<ScoreController>().addScore(1);
        GameObject.FindGameObjectWithTag("KingUI").GetComponent<KingBehaviour>().AddLaughter(1);
        orderPlacer.AdvanceState();
    }

    public virtual void discard()
    {
        StartCoroutine(orderPlacer.Angery());
        fulfilled = true;
        GameObject.FindGameObjectWithTag("ScoreUI").GetComponent<ScoreController>().addScore(-1);
        GameObject.FindGameObjectWithTag("KingUI").GetComponent<KingBehaviour>().AddLaughter(5);
        orderPlacer.AdvanceState();
    }
}
