using UnityEngine;
using System.Collections;


public class C4 : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float radius = 5.0F;
    [SerializeField] private float power = 700.0F;
    [SerializeField] private float selfPower = 1.0F;

    private GameObject _bigExplosion;
    private ParticleSystem _explosion;
    private ParticleSystem _generatedExplosion;
    private GameObject _lastPoint;
    private AudioSource _barrelExplosionSound;

    private void Start()
    {
        _lastPoint = GameObject.FindGameObjectWithTag("LastPoint");
        _bigExplosion = GameObject.FindGameObjectWithTag("Explosion");
        _explosion = _bigExplosion.GetComponent<ParticleSystem>();
        _barrelExplosionSound = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        if (other.gameObject.CompareTag("Enemy"))
        {
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 1.0F);
                    gameObject.GetComponent<Rigidbody>().AddExplosionForce(selfPower, explosionPos, radius, 1.0F);
                }
            }

            var enemy = other.GetComponent<EnemyDamage>();
            enemy.Hurt(_damage);

            _barrelExplosionSound.Play();
            StartExplosion();
        }
    }

    private void StartExplosion()
    {
        _generatedExplosion = Instantiate(_explosion, gameObject.transform.position, Quaternion.identity);
        _generatedExplosion.Play();

        StartCoroutine(StopExplosion(_generatedExplosion.main.duration));
    }

    private IEnumerator StopExplosion(float delay)
    {
        gameObject.transform.position = _lastPoint.transform.position;
        yield return new WaitForSeconds(delay - 0.1f);
        _generatedExplosion.Stop();
        Destroy(gameObject);
    }
}