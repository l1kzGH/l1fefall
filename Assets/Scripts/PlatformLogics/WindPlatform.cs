using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPlatform : MonoBehaviour
{
    public float windPower = 0.05f;
    public float changeTime = 2f;
    private float windDirection = 1f;

    public ParticleSystem windParticles;
    private ParticleSystem.ShapeModule shape;

    // Start is called before the first frame update
    void Start()
    {
        shape = windParticles.shape;

        StartCoroutine(ChangeWindDirection());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ChangeWindDirection()
    {
        while (true)
        {
            // n.t. = 2 directions
            yield return new WaitForSeconds(changeTime);
            windDirection = -windDirection; // direction-change

            Vector3 shapePosition = shape.position;
            var velModule = windParticles.velocityOverLifetime;
            if (windDirection > 0)
            {
                shapePosition.x = 15f;
                shape.rotation = new Vector3(0, 270f, 0);
            }
            else
            {
                shapePosition.x = -15f;
                shape.rotation = new Vector3(0, 90f, 0);
            }
            shape.position = shapePosition;

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(new Vector3(windPower * -windDirection, 0, 0), ForceMode.Impulse);
            }
        }
    }

}
