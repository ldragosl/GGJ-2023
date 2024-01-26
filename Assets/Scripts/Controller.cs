using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Controller instance;
    public Rigidbody rb;
    float xRotation;
    float yRotation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
