using UnityEngine;
using UnityEngine.UI;


public class WeaponVolume : MonoBehaviour
{
    private Scrollbar _weaponVolume;
    private GameObject _hero;
    private AudioSource _audioSource;

    private void Start()
    {
        _hero = GameObject.FindGameObjectWithTag("Hero");
        _audioSource = _hero.GetComponent<AudioSource>();

        _weaponVolume = gameObject.GetComponent<Scrollbar>();
        _weaponVolume.value = 0.2f;
    }

    private void Update()
    {
        _audioSource.volume = _weaponVolume.value;
    }
}
