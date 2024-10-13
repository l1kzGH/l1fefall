using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepDamagePlatform : MonoBehaviour
{


    public HealthBar healthBar;
    public int damage = 50;
    private Color origColor;
    private Renderer platformRenderer;
    private bool isPlayerOnPlatform = false;
    private bool cooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        origColor = platformRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !cooldown)
        {
            isPlayerOnPlatform = true;
            StartCoroutine(DamageOperation());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }

    private IEnumerator DamageOperation()
    {
        cooldown = true;
        // to-orange
        platformRenderer.material.color = new Color(1f, 0.5f, 0f);
        // 1s
        yield return new WaitForSeconds(1f);
        // to-red
        platformRenderer.material.color = Color.red;

        if (isPlayerOnPlatform)
        {
            // damage to player
            healthBar.GetDamage(damage);
        }
        // 5 sec to reload
        yield return new WaitForSeconds(5f);
        // back-color
        platformRenderer.material.color = origColor;

        cooldown = false;
    }
}
