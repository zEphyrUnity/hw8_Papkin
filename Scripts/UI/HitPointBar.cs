using UnityEngine;
using UnityEngine.UI;


public class HitPointBar : MonoBehaviour
{
    private Image _hitPointBar;

    private void Update()
    {
        _hitPointBar = gameObject.GetComponent<Image>();
        _hitPointBar.fillAmount = (float)Health.health / 100;
    }
}
