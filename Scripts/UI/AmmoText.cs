using TMPro;
using UnityEngine;


public class AmmoText : MonoBehaviour
{
    private TextMeshProUGUI _ammoText;

    private void Start()
    {
        _ammoText = gameObject.GetComponent<TextMeshProUGUI>();
        _ammoText.color = Color.yellow;
    }

    private void Update()
    {
        _ammoText.text = $"Ammo {Reinforcement.ammunition}";
        _ammoText.fontStyle = FontStyles.LowerCase;
    }
}
