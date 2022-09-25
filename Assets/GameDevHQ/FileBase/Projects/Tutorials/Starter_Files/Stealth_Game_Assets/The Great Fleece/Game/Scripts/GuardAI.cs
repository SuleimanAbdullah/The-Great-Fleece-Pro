using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _wayPoints;
    [SerializeField]
    private Transform _currentWayPoint;
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        if (_wayPoints.Count > 0)
        {
            if (_wayPoints[0] != null)
            {
                _currentWayPoint = _wayPoints[0];
                _agent.SetDestination(_currentWayPoint.position);
            }
        }

    }


}
