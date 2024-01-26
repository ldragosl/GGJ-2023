using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Controller instance;
    public Rigidbody rb;
    public float groundDrag;
    float horizontalInput;
    float verticalInput;
    public Transform orientation;
    public Transform cameraPos;
    Vector3 moveDirection;
    [SerializeField] float speed = 5;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //rb.freezeRotation=true;
    }


    Vector2 rotation = Vector2.zero;
    // Update is called once per frame
    void Update()    
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        SpeedControll();
        rb.drag = groundDrag;
    }

    public void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    public void MovePlayer()
    {
        moveDirection = orientation.transform.forward * verticalInput + orientation.transform.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * speed * 10f , ForceMode.Force);
    }

    public void SpeedControll()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}