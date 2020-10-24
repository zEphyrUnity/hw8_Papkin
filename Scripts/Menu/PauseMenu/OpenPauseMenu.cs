using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpenPauseMenu : MonoBehaviour
{
    public static string activeScene;
    public static bool _gameIsPaused = false;

    private void Start()
    {
        activeScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") & !_gameIsPaused)
        {
            Debug.Log("Escape");
            SceneManager.LoadScene("MenuPause", LoadSceneMode.Additive);
            StartCoroutine(SetMenuPauseActive());

            _gameIsPaused = true;
            Time.timeScale = 0f;
        }
    }

    IEnumerator SetMenuPauseActive()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("SetActive");
    }
}
