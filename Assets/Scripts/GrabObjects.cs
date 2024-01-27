using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    Transform hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit))
            {
                if (hit.collider.tag=="interactable")
                {
                    GameObject pickedItem = hit.collider.gameObject;
                    pickedItem.GetComponent<Rigidbody>().isKinematic = true;
                    pickedItem.transform.position = hand.position;
                }
            }
        }
    }
}
