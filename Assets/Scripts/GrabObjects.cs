using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    public Transform hand;
    GameObject pickedItem;
    public bool isPicked;
    // Start is called before the first frame update
    void Start()
    {
        isPicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPicked == false)
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(mouseRay, out hit))
                {

                    if (hit.collider.tag == "Interactable")
                    {
                        pickedItem = hit.collider.gameObject;
                        pickedItem.GetComponent<Rigidbody>().isKinematic = true;
                        pickedItem.transform.position = hand.position;
                        pickedItem.transform.rotation = Quaternion.Euler(-90, 0, 180 );
                        pickedItem.transform.parent = hand;
                        pickedItem.GetComponent<Collider>().enabled = false;
                        isPicked = true;
                    }
                }
            }
            else
            if (isPicked == true)
            {
                pickedItem.GetComponent<Rigidbody>().isKinematic = false;
                pickedItem.transform.parent = null;
                isPicked = false;
                pickedItem.GetComponent<Collider>().enabled = true;
            }
        }
    }
}
