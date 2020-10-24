using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class QuitToMain : MonoBehaviour
{
    public Button yourButton;

    private void Start()
    {
        Button _toMain = yourButton.GetComponent<Button>();
        _toMain.onClick.AddListener(BackToMain);
    }

    private void BackToMain()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
}
