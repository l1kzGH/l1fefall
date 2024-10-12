using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timeText;
    private float elapseTime;
    private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        elapseTime = 0f;
        isRunning = false;
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            elapseTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        elapseTime = 0f;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapseTime / 60);
        int seconds = Mathf.FloorToInt(elapseTime % 60);
        int milliseconds = Mathf.FloorToInt((elapseTime * 100) % 100);

        timeText.text = string.Format("{0}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public IEnumerator MoveByWin()
    {
        float elapsedTime = 0f;
        float duration = 5f;

        RectTransform rectTransform = timeText.GetComponent<RectTransform>();

        Vector2 endPos = new Vector2(0, 60);

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;

            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, endPos, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = endPos;
    }

}
