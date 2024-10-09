using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{

    public float speed = 5f;
    public float jumpPower = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    // FixedUpdate for rigidbody and physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * speed;

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

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
        else
        {
            Debug.Log("Contact with ?: " + collidedObjectName);
        }
    }
}
