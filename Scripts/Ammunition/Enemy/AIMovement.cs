using UnityEngine;
using UnityEngine.AI;
using Utils;


public class AIMovement : MonoBehaviour
{
    private GameObject _hero;
    private NavMeshAgent _agent;
    private Transform _enemyTransform;
    private TransformData _patrolPointsA;
    private TransformData _patrolPointsB;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _hero = GameObject.FindGameObjectWithTag("Hero");
        _enemyTransform = GetComponent<Transform>();

        _patrolPointsA = _enemyTransform.Clone(); 
        _patrolPointsB = _enemyTransform.Clone();

        Vector3 _tmp = _patrolPointsB.position;
        _tmp.x += 5;                                 
        _patrolPointsB.position = _tmp;
    }

    private void Update()
    {
        Vector3 vectorToPointA = gameObject.transform.position - _patrolPointsA.position;
        Vector3 vectorToPointB = gameObject.transform.position - _patrolPointsB.position;
        Vector3 vectorToHero =  gameObject.transform.position - _hero.transform.position;

        if (vectorToHero.magnitude < 20)
        {
            _agent.SetDestination(_hero.transform.position);
        }
        else
        {
            if (vectorToPointA.magnitude < 1)
            {
                _agent.SetDestination(_patrolPointsB.position);
            }
            if (vectorToPointB.magnitude < 1)
            {
                _agent.SetDestination(_patrolPointsA.position);
            }
        }
    }
}