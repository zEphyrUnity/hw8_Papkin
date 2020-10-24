using TMPro;
using UnityEngine;


public class HitPointText : MonoBehaviour
{
    private TextMeshProUGUI _hitPointText;

    private void Start()
    {
        _hitPointText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _hitPointText.text = $"{Health.health}";

        if (Health.health < 30)
            _hitPointText.color = Color.red;

        if (Health.health > 30 & Health.health < 60)
            _hitPointText.color = Color.yellow;

        if (Health.health > 60)
            _hitPointText.color = Color.green;
    }
}
