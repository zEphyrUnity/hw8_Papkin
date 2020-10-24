using UnityEngine;


public class TurretTrackingAi : MonoBehaviour
{
    [SerializeField] float speed = 50.0f;

    [SerializeField] GameObject m_target = null;
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookAtRotation;

    void Update()
    {
        if (m_target)
        {
            if (m_lastKnownPosition != m_target.transform.position)
            {
                m_lastKnownPosition = m_target.transform.position;
                m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
            }

            if (transform.rotation != m_lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
            }
        }
    }
}
