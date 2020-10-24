using UnityEngine;


public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float _health = 10f;

    public void Hurt(float damage)
    {
        _health -= damage;
        Debug.LogWarning($"Ouch: {damage} {_health}");

        if (_health <= 0)
        {
            Invoke("Die", 0.3F);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
