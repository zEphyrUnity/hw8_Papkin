using UnityEngine;
using UnityEngine.UI;


public class Back : MonoBehaviour
{
    [SerializeField] private Button _yourButton;
    [SerializeField] private GameObject _optionMenu;
    [SerializeField] private GameObject _pauseMenu;

    private void Start()
    {
        Button _options = _yourButton.GetComponent<Button>();
        _options.onClick.AddListener(OptionsMenu);
    }

    private void OptionsMenu()
    {
        _optionMenu.SetActive(false);
        _pauseMenu.SetActive(true);
    }
}
