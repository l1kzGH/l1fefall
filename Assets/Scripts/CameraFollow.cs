using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTransform; // Main-person
    public float mouseSensitivity = 500f;
    private float height = 2f; // above
    private float distance = 3f; // from
    private float xRotation = 0f; // Вращение по оси X

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // cursor turns OFF
        //Cursor.lockState = CursorLockMode.None; // to unlock
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Debug.Log($"Mouse X: {mouseX}, Mouse Y: {mouseY}");

        // Y
        playerTransform.Rotate(Vector3.up * mouseX);

        // xRotation update
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -15f, 45f); // lock

        // Fix-pos
        Quaternion rotation = Quaternion.Euler(xRotation, playerTransform.eulerAngles.y, 0); // Угол поворота камеры
        Vector3 desiredPosition = playerTransform.position - rotation * Vector3.forward * distance + Vector3.up * height;

        transform.position = desiredPosition;

        transform.LookAt(playerTransform.position + Vector3.up * height);
    }

    // void LateUpdate()
    // {
    //     Vector3 desiredPosition = playerTransform.position + new Vector3(0, height, -distance);
    //     transform.position = desiredPosition;
    //     transform.LookAt(playerTransform);
    // }
}
