using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour
{

    public Button resButton;
    // public GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        resButton.gameObject.SetActive(false);
        resButton.onClick.AddListener(RestartLevel); // Restart-listener
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayerDeath()
    {
        Cursor.lockState = CursorLockMode.None;
        resButton.gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        // 1:Scene-reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // 2:Non-scene-reload (player to start-point ...)
        // playerObj.transform.position = startPosition; // Укажите нужную стартовую позицию
        // restartButton.gameObject.SetActive(false); // Убираем кнопку после рестарта
    }
}
