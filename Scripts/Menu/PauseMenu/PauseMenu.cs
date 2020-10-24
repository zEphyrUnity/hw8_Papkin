using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}