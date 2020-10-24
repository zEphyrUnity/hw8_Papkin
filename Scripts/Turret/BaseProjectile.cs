using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    public float speed = 5.0f;

    public abstract void FireProjectile(GameObject launcher, GameObject target, int damage, float attackSpeed); 
}
