using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabObjects : MonoBehaviour
{
    public Transform hand;
    public Transform stoveSpot;
    GameObject pickedItem;
    public bool isPicked;
    public int range = 4;
    public TMP_Text pickUpText;


    // Start is called before the first frame update
    void Start()
    {
        isPicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        pickUpText.enabled = false;
        if (isPicked == false)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit))
            {
                if (hit.collider.tag == "Interactable" && Vector3.Distance(hit.collider.gameObject.transform.position, gameObject.transform.position) <= range)
                {
                    pickUpText.gameObject.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        pickedItem = hit.collider.gameObject;
                        pickedItem.GetComponent<Rigidbody>().isKinematic = true;
                        pickedItem.transform.position = hand.position;
                        pickedItem.transform.rotation = Quaternion.Euler(-90, 0, 180);
                        pickedItem.transform.parent = hand;
                        pickedItem.GetComponent<Collider>().enabled = false;
                        isPicked = true;
                        pickUpText.enabled = false;
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
                        pickedItem.transform.position = stoveSpot.position;
                        pickedItem.transform.parent = null;
                        isPicked = false;
                        pickedItem.GetComponent<Collider>().enabled = true;
                    }
                    else
                    {
                        pickedItem.GetComponent<Rigidbody>().isKinematic = false;
                        pickedItem.transform.parent = null;
                        isPicked = false;
                        pickedItem.GetComponent<Collider>().enabled = true;
                    }
            }
        }
    }
}
