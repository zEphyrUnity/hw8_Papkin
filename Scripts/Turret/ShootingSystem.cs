using UnityEngine;
using System.Collections.Generic;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private int damage;
    [SerializeField] private float fieldOfView;
    [SerializeField] private bool beam;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject target;
    [SerializeField] private List<GameObject> projectileSpawns;

    List<GameObject> m_lastProjectiles = new List<GameObject>();
    float m_fireTimer = 0.0f;

    void Update()
    {
        var distanceVector = target.transform.position - gameObject.transform.position;

        var distanceToTarget = distanceVector.magnitude;

        if(distanceToTarget > 10)
        {
            if (beam && m_lastProjectiles.Count <= 0)
            {
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));

                if (angle < fieldOfView)
                {
                    SpawnProjectiles();
                }
            }
        }
        else if (beam && m_lastProjectiles.Count > 0)
        {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));

            if (angle > fieldOfView)
            {
                while(m_lastProjectiles.Count > 0)
                {
                    Destroy(m_lastProjectiles[0]);
                    m_lastProjectiles.RemoveAt(0);
                }
            }
        }
        else
        {
            m_fireTimer += Time.deltaTime;

            if (m_fireTimer >= fireRate)
            {
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));

                if (angle < fieldOfView)
                {
                    SpawnProjectiles();

                    m_fireTimer = 0.0f;
                }
            }
        }
    }

    void SpawnProjectiles()
    {
        if (!projectile)
        {
            return;
        }

        m_lastProjectiles.Clear();

        for (int i = 0; i < projectileSpawns.Count; i++)
        {
            if (projectileSpawns[i])
            {
                GameObject proj = Instantiate(projectile, projectileSpawns[i].transform.position, Quaternion.Euler(projectileSpawns[i].transform.forward)) as GameObject;
                proj.GetComponent<BaseProjectile>().FireProjectile(projectileSpawns[i], target, damage, fireRate);

                m_lastProjectiles.Add(proj);
            }
        }
    }
}