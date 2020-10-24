using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NewGame : MonoBehaviour
{
    public Button yourButton;

    private void Start()
    {
        Button _newGame = yourButton.GetComponent<Button>();
        _newGame.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("LevelOne", LoadSceneMode.Single);
    }   
}
