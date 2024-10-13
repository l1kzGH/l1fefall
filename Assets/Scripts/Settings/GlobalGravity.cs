using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGravity : MonoBehaviour
{

    public float zForce = -20f;

    // Start is called before the first frame update
    void Start()
    {
        // Level gravity-logic
        Physics.gravity = new Vector3(0, zForce, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
