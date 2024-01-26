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
    Vector3 moveDirection;
    [SerializeField] float speed = 3;
    [Range(0.1f, 9f)] [SerializeField] float playerSensitivity = 2f;
    [Range(0f, 90f)] [SerializeField] float yRotationLimit = 88f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    const string yAxis = "Mouse Y";
    public float Sensitivity
    {
        get { return playerSensitivity; }
        set { playerSensitivity = value; }

    }
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
        rotation.y += Input.GetAxis(yAxis) * playerSensitivity;
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);
        transform.rotation = yQuat;
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