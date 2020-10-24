using UnityEngine;


public class Spawner : MonoBehaviour
{
    private const int _quantity = 10;
    [SerializeField] private GameObject[] _objects;
    private Vector3 _spawnPosition;
    private float _spawnTime = 3f;
    private int _invokeSize = 0;

    void Start()
    {
        InvokeRepeating("Spawn", _spawnTime, _spawnTime);
    }

    void Spawn()
    {
        _spawnPosition.x = Random.Range(-44, 20);
        _spawnPosition.y = 0.1f;
        _spawnPosition.z = Random.Range(-22, -32);

        Instantiate(_objects[0], _spawnPosition, Quaternion.identity);

        _invokeSize++;
        if (_invokeSize >= _quantity)
            CancelInvoke();
    }
}


