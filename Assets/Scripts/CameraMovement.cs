using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform orientation;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)] [SerializeField] float yRotationLimit = 88f;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";
    [SerializeField] float sensitivity = 400f;

    Vector2 rotation = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX= Input.GetAxisRaw(xAxis) * Time.deltaTime * sensitivity;
        float mouseY= Input.GetAxisRaw(yAxis) * Time.deltaTime * sensitivity;
        rotation.x -= mouseY;
        rotation.y += mouseX;
        rotation.x = Mathf.Clamp(rotation.x, -yRotationLimit, yRotationLimit);
        transform.rotation = Quaternion.Euler(rotation.x,rotation.y,0);
        orientation.rotation = Quaternion.Euler(0, rotation.y, 0);
    }
}
