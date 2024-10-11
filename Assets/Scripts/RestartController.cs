using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartController : MonoBehaviour
{
    public Button resButton;
    public TMP_Text loseText;
    public TMP_Text winText;

    // Start is called before the first frame update
    void Start()
    {
        loseText.alpha = 0;
        winText.alpha = 0;

        resButton.onClick.AddListener(RestartLevel); // Restart-listener
        resButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowLoseText()
    {
        Debug.Log("Lose");
        // fast-momental
        // Color textColor = loseText.color;
        // textColor.a = 1.0f; 
        // loseText.color = textColor;

        // slowly
        StartCoroutine(FadeTextToFullAlpha(loseText, 3f));
    }

    public IEnumerator FadeTextToFullAlpha(TMP_Text text, float duration)
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

        OnPlayerDeathWin();
    }

    private void OnPlayerDeathWin()
    {
        Cursor.lockState = CursorLockMode.None;
        resButton.gameObject.SetActive(true);
    }

    private void RestartLevel()
    {
        // scene-reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowWinText()
    {
        Debug.Log("Win");
        StartCoroutine(FadeTextToFullAlpha(winText, 3f));
    }
}
