using UnityEngine;


public class HeroDamage : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    public void Hurt(float damage)
    {
        print("Ouch: " + damage);

        Health.health -= damage;

        if (Health.health <= 0)
        {
            Invoke("Die", 1F);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        _menu.SetActive(true);
    }
}
