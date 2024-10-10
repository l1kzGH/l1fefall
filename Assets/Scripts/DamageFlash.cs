using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public Image leftDamagePanel, rightDamagePanel, upperDamagePanel, downDamagePanel;
    public float flashDuration = 0.5f;
    private float flashTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
            SetEdgeAlpha(Mathf.Lerp(1, 0, 1 - (flashTimer / flashDuration)));
        }
        else
        {
            SetEdgeAlpha(0);
        }
    }

    public void TriggerFlash()
    {
        flashTimer = flashDuration;
        SetEdgeAlpha(1);
    }

     private void SetEdgeAlpha(float alpha)
    {
        Color leftColor = leftDamagePanel.color;
        Color rightColor = rightDamagePanel.color;
        Color topColor = upperDamagePanel.color;
        Color bottomColor = downDamagePanel.color;

        leftColor.a = alpha;
        rightColor.a = alpha;
        topColor.a = alpha;
        bottomColor.a = alpha;

        leftDamagePanel.color = leftColor;
        rightDamagePanel.color = rightColor;
        upperDamagePanel.color = topColor;
        downDamagePanel.color = bottomColor;
    }
}
