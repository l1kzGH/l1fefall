using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{

    public float speed = 5f;
    public float jumpPower = 5f;
    private Rigidbody rb;
    private Camera mainCamera;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        isGrounded = true;
    }

    // FixedUpdate for rigidbody and physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = mainCamera.transform.forward; // forward
        Vector3 cameraRight = mainCamera.transform.right; // right

        // remove Y-const
        cameraForward.y = 0; 
        cameraRight.y = 0;

        // normalizin
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized * speed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    private void Update() {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        isGrounded = false; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collidedObjectName = collision.gameObject.name;
        
        // Debug.log for debugging the object-collisions-with
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Contact with ground: " + collidedObjectName);
            isGrounded = true;
        }
        // else
        // {
        //     Debug.Log("Contact with ?: " + collidedObjectName);
        // }
    }
}
