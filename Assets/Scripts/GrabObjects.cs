using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabObjects : MonoBehaviour
{
    public static GrabObjects singleton;

    [SerializeField] Transform hand;
    public Transform stoveSpot;
    public bool isPicked;
    public int range = 4;
    public TMP_Text pickUpText;
    public GameObject currentItem;

    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.FindGameObjectWithTag("Hand").transform;
        singleton = this;
        isPicked = false;
        currentItem = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit))
        {
                //pickUpText.gameObject.SetActive(true);
                if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.GetComponent<PickupableObject>() && Vector3.Distance(hit.collider.gameObject.transform.position, gameObject.transform.position) <= range)
                {
                  
                if(currentItem)
                {
                    if (currentItem.tag == "Pan")
                    {
                       // hit.collider.gameObject.transform.parent = currentItem.transform;
                        GrabObject(hit.collider.gameObject);
                    }
                }

                if (isPicked == false)
                {
                    currentItem = hit.collider.gameObject;
                    GrabObject(currentItem);
                }

                }

        }

        if (Input.GetMouseButtonDown(1) && isPicked == true)
        {

            /*if (currentItem.tag == "Pan")
            {
                if (hit.collider.tag == "Stove")
                {
                    currentItem.transform.position = stoveSpot.position;
                    currentItem.transform.parent = null;
                    isPicked = false;
                    currentItem.GetComponent<Collider>().enabled = true;
                }
            }*/
            
            {
                DropItem(currentItem);
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
        //currentItem = null;
    }
}
