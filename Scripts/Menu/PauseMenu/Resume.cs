using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    public Button yourButton;

    private void Start()
    {
        Button resume = yourButton.GetComponent<Button>();
        resume.onClick.AddListener(Unpause);
    }

    private void Unpause()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
