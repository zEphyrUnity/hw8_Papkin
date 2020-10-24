using UnityEngine;


public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _lerpSpeed = 0.3f;

    private void Awake()
    {
        transform.rotation = Quaternion.LookRotation(Movement.movement);
        transform.rotation = Quaternion.Euler(20f, 0, 0);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, GetCurrentPlayerPosition(), _lerpSpeed);
    }

    private Vector3 GetCurrentPlayerPosition()
    {
        return _playerTransform.position + new Vector3(0f, 5f, -10f);
    }
}
