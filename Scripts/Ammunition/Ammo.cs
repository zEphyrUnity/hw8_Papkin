using System.Collections;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int ammo = 15;
    private GameObject _lastPoint;
    private AudioSource _audioSource;

    private void Start()
    {
        _lastPoint = GameObject.FindGameObjectWithTag("LastPoint");
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            var hero = other.GetComponent<Reinforcement>();
            hero.TakeAmmo(ammo);

            _audioSource.Play();
            StartCoroutine(DelayDestroyObject(_audioSource.clip.length));
        }
    }

    IEnumerator DelayDestroyObject(float delay)
    {
        gameObject.transform.position = _lastPoint.transform.position;
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}