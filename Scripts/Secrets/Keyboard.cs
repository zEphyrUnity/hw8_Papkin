using UnityEngine;


public class Keyboard : MonoBehaviour
{
    private GameObject _barrelBomb;
    private GameObject _startPosition;

    private void Start()
    {
        _barrelBomb = GameObject.FindGameObjectWithTag("Barrel");
        _startPosition = GameObject.FindGameObjectWithTag("KeyboardSecretStartPosition");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Box"))
            Invoke("SpawnBombs", 1);

    }

    private void SpawnBombs()
    {
        Instantiate(_barrelBomb, _startPosition.transform);
    }
}
