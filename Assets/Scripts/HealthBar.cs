using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 100;
    private int currHealth;

    public GameObject playerObj;
    public DamageFlash damageFlash;
    public RestartController restartController;
    public PlayerMov playerMov;

    private bool status = false;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GetComponent<Slider>();

        // set start-default values
        currHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth > 0 && playerObj.transform.position.y < -50)
        {
            GetDamage(10);
        }
        if (currHealth == 0 && !status)
        {
            status = true;
            PlayerDeath();
            restartController.ShowLoseText();
        }
    }

    public void GetDamage(int damage)
    {
        currHealth -= damage;
        healthSlider.value = currHealth;

        // ui flashing
        damageFlash.TriggerFlash();
    }

    private void PlayerDeath()
    {
        // unpin "Freeze Rotation"
        Rigidbody rb = playerObj.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;

        // remove all controls
        if (playerMov)
        {
            Destroy(playerMov);
        }
    }

}