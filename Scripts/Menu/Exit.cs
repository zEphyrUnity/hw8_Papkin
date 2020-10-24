using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Button yourButton;

    private void Start()
    {
        Button _exitButton = yourButton.GetComponent<Button>();
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else      
                Application.Quit();
        #endif
    }
}
