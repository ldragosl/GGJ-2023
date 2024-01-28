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
    public bool hasMeat = false;

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
        if(isPicked && currentItem == null)
        {
            isPicked = false;
        }

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit))
        {
                //pickUpText.gameObject.SetActive(true);
                if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.GetComponent<PickupableObject>() && Vector3.Distance(hit.collider.gameObject.transform.position, gameObject.transform.position) <= range)
                {
                  
                if(currentItem)
                {
                    if (currentItem.tag == "Pan" && hasMeat == false)
                    {
                       // hit.collider.gameObject.transform.parent = currentItem.transform;
                        GrabObject(hit.collider.gameObject);
                        hit.collider.gameObject.transform.parent = currentItem.transform;
                        hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                        hasMeat = true;
                    }
                }

                if (isPicked == false)
                {
                    currentItem = hit.collider.gameObject;
                    GrabObject(currentItem);
                    isPicked = true;
                }

                }

        }

        if (Input.GetMouseButtonDown(1) && isPicked == true)
        {
            if (hit.collider != null && hit.collider.tag == "Stove")
            {
                if (currentItem.tag == "Pan")
                {
                    currentItem.transform.position = stoveSpot.position;
                    currentItem.transform.parent = null;
                    isPicked = false;
                    currentItem.GetComponent<Collider>().enabled = true;
                    currentItem = null;
                }
            }
            
            {
                DropItem(currentItem);
                isPicked = false;
            }
        }
    }
    

    public void GrabObject(GameObject pickedItem)
    {
        pickedItem.GetComponent<PickupableObject>().OnPickup();
        
    }

    public void DropItem(GameObject currentItem)
    {
        currentItem.GetComponent<PickupableObject>().Drop();
        
        currentItem = null;
    }
}
