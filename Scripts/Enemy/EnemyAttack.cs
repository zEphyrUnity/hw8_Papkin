using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    private float _hitForceForward = 100;
    private float _hitForceUp = 5;
    private float _damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            Rigidbody _heroRigidbody = other.GetComponent<Rigidbody>();
            HeroDamage _heroDamage = other.GetComponent<HeroDamage>();

            var impulse = transform.forward * _heroRigidbody.mass * _hitForceForward + transform.up * _hitForceUp;
            _heroRigidbody.AddForce(impulse, ForceMode.Impulse);
            _heroDamage.Hurt(_damage);
        }
    }
}
