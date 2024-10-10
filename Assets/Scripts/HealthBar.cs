using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 100;
    private int currHealth;
    public GameObject playerObj;
    public DamageFlash damageFlash;
    public TMP_Text loseText;
    private bool status = false;
    public RestartController restartController;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GetComponent<Slider>();

        // set start-default values
        currHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currHealth;
        loseText.alpha = 0;
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
            ShowLoseText();
        }
    }

    public void GetDamage(int damage)
    {
        currHealth -= damage;
        healthSlider.value = currHealth;

        // ui flashing
        damageFlash.TriggerFlash();
    }

    private void ShowLoseText()
    {
        Debug.Log("Lose");
        // fast-momental
        // Color textColor = loseText.color;
        // textColor.a = 1.0f; 
        // loseText.color = textColor;

        // slowly
        StartCoroutine(FadeTextToFullAlpha(loseText, 3f));
    }

    private IEnumerator FadeTextToFullAlpha(TMP_Text text, float duration)
    {
        Color startColor = text.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            text.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        text.color = endColor;
        // reset-button
        restartController.OnPlayerDeath();
    }

}