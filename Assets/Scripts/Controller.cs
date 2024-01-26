using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Controller instance;
    public Rigidbody rb;
    float xRotation;
    float yRotation;
    public float groundDrag;
    float horizontalInput;
    float verticalInput;
    public Transform orientation;
    Vector3 moveDirection;
    [SerializeField] float speed = 3;
    [Range(0.1f, 9f)] [SerializeField] float sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)] [SerializeField] float yRotationLimit = 88f;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";
    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }

    }

    Vector2 rotation = Vector2.zero;
     

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible = false;
        rb.freezeRotation=true;
    }

    // Update is called once per frame
    void Update()    
    {
        MyInput();
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat * yQuat;
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