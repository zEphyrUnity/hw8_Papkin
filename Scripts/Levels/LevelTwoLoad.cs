using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwoLoad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
            SceneManager.LoadScene("LevelTwo", LoadSceneMode.Single);
    }
}
