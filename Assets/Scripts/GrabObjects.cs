using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabObjects : MonoBehaviour
{
    public static GrabObjects singleton;

    public Transform hand;
    public Transform stoveSpot;
    public bool isPicked;
    public int range = 4;
    public TMP_Text pickUpText;
    public GameObject currentItem;
    
    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
        isPicked = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isPicked == false)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit))
            {
                if (hit.collider.gameObject.GetComponent<PickupableObject>() && Vector3.Distance(hit.collider.gameObject.transform.position, gameObject.transform.position) <= range)
                {
                    pickUpText.gameObject.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        currentItem = hit.collider.gameObject;
                        GrabObject(currentItem);
                    }
                }
            }
        }

        if (isPicked == true)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(mouseRay, out hit))
                    if (hit.collider.tag == "Stove")
                    {
                        currentItem.transform.position = stoveSpot.position;
                        currentItem.transform.parent = null;
                        isPicked = false;
                        currentItem.GetComponent<Collider>().enabled = true;
                    }
                    else
                    {
                        DropItem(currentItem);
                    }
            }
        }
    }
    

    public void GrabObject(GameObject pickedItem)
    {
        pickedItem.GetComponent<PickupableObject>().OnPickup();
        isPicked = true;
    }

    public void DropItem(GameObject currentItem)
    {
        currentItem.GetComponent<PickupableObject>().Drop();
        isPicked = false;
    }
}
