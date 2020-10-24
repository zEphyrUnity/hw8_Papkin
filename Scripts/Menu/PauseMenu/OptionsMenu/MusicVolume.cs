using UnityEngine;
using UnityEngine.UI;


public class MusicVolume : MonoBehaviour
{
    private Scrollbar _musicVolume;
    private GameObject _playerCamera;
    private AudioSource _audioSource;

    private void Start()
    {
        _playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera");
        _audioSource = _playerCamera.GetComponent<AudioSource>();

        _musicVolume = gameObject.GetComponent<Scrollbar>();
        _musicVolume.value = 0.1f;
    }

    private void Update()
    {
        _audioSource.volume = _musicVolume.value;
    }
}
