using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2f;
    private float xRotation = 0f;

    void Awake()
    {
        //Locks the cursor
        Cursor.lockState = CursorLockMode.Locked;

        // Cursor.lockState = CursorLockMode.Confined;

        //Hides the cursor
        Cursor.visible = false;
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY;

        //Makes sure the player can only look 90 degrees up and down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);

        
    }
}
