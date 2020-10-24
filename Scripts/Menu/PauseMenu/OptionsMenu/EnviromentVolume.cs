using UnityEngine;
using UnityEngine.UI;


public class EnviromentVolume : MonoBehaviour
{
    private Scrollbar _enviromentVolume;
    
    private GameObject _barrel;
    private GameObject _aidKit;
    private GameObject _ammoBox;

    private AudioSource _audioSourceBarrel;
    private AudioSource _audioSourceAidKit;
    private AudioSource _audioSourceAmmoBox;

    private void Start()
    {
        _barrel = GameObject.FindGameObjectWithTag("Barrel");
        _audioSourceBarrel = _barrel.GetComponent<AudioSource>();

        _aidKit = GameObject.FindGameObjectWithTag("AidKit");
        _audioSourceAidKit = _aidKit.GetComponent<AudioSource>();

        _ammoBox = GameObject.FindGameObjectWithTag("AmmoBox");
        _audioSourceAmmoBox = _ammoBox.GetComponent<AudioSource>();

        _enviromentVolume = gameObject.GetComponent<Scrollbar>();
        _enviromentVolume.value = 0.1f;
    }

    private void Update()
    {
        _audioSourceBarrel.volume = _enviromentVolume.value;
        _audioSourceAidKit.volume = _enviromentVolume.value;
        _audioSourceAmmoBox.volume = _enviromentVolume.value;
    }
}
