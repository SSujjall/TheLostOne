using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 300f;

    float XRotation = 0f;
    float YRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (InventorySystem.Instance.isOpen == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            //control rotation around x axis (Look up and down)
            XRotation -= mouseY;

            //we clamp the rotation so we cant Over-rotate (like in real life)
            XRotation = Mathf.Clamp(XRotation, -90f, 90f);

            //control rotation around y axis (Look up and down)
            YRotation += mouseX;

            //applying both rotations
            transform.localRotation = Quaternion.Euler(XRotation, YRotation, 0f);
        }
    }
}
