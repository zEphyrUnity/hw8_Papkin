using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _impulseMultiplier = 15;

    private Vector3 impulse;
    private Vector3 bulletImpulse;

    private Rigidbody _rigidbody;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
        _rigidbody = GetComponent<Rigidbody>();

        impulse = transform.right * _rigidbody.mass * _speed;
        _rigidbody.AddForce(impulse, ForceMode.Impulse);

        bulletImpulse = transform.right * _rigidbody.mass * _impulseMultiplier;
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody enemyRigidbody = other.GetComponent<Rigidbody>();

        if (other.CompareTag("Enemy"))
        {
            enemyRigidbody.AddForce(bulletImpulse, ForceMode.Impulse);
            var enemy = other.GetComponent<EnemyDamage>();
            enemy.Hurt(_damage);
        }
    }
}
