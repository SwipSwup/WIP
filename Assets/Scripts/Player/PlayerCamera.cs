using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float mouseSens = 50f;
    [SerializeField] float lagLimit = 100f;
    [SerializeField] bool lockMouse = true;
    [SerializeField] Transform playerTransform;


    private void Start()
    {
        Cursor.lockState = lockMouse ? CursorLockMode.Locked : CursorLockMode.None;
    }

    private void Update()
    {
        LookWithMouse();
    }

    private float xRotation = 0f;
    private void LookWithMouse()
    {
        if (Time.deltaTime > lagLimit) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
