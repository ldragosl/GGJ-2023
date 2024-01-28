using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;
    public List<Order> orders;

    private float lastOrderTime = 0f;
    private float lastUpdate = 0f;
    public bool showDebug = false;
    public void addOrder(Order order)
    {
        orders.Add(order);
    }

    public void fulfillNamedOrder(string orderName)
    {
        foreach (Order order in orders) {
            if(order.orderName == orderName)
            {
                //fulfill the first order and remove it from the list
                order.fulfill();
                removeOrder(order.orderId);
                break;
            }
        }
    }

    private void removeOrder(int orderId)
    {
        orders = orders.Where(val => val.orderId != orderId).ToList();
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        orders = new List<Order> ();
    }

    void placeNewOrder(NobleBehavior placer)
    {
        var comp = gameObject.AddComponent<CookedMeatOrder>();
        comp.orderPlacer = placer;
        addOrder(comp);
    }

    // Update is called once per frame
    void Update()
    {
        List<int> ordersToRemove = new List<int>();
        foreach(Order order in orders)
        {
            order.timeLeft -= Time.deltaTime;
            if(order.timeLeft < 0)
            {
                order.discard();
                ordersToRemove.Add(order.orderId);
            }
        }
        orders = orders.Where(val => !ordersToRemove.Contains(val.orderId)).ToList();

        if (showDebug && Time.time - lastUpdate > 0.5f)
        {
            lastUpdate = Time.time;
            Debug.Log("*****************New menu update: " + lastUpdate);
            foreach (Order order in orders)
            {
                Debug.Log("Order id " + order.orderId + ", order message: " + order.orderName + ", timeLeft: " + order.timeLeft);
            }
        }
    }
}
