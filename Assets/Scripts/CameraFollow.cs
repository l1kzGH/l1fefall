using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // Main-person
    public float height = 2f; // above
    public float distance = 3f; // from

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 desiredPosition = target.position + new Vector3(0, height, -distance);
        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}
