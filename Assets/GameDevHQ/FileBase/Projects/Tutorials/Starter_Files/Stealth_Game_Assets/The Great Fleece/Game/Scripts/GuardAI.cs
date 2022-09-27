using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _wayPoints;
    private NavMeshAgent _agent;
    [SerializeField]
    private int _currentWayPointID;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //calculate distance btwn guard and destination point
        //check if guard reach destination
        //increament current waypointID
        //avoid to increment more than a size of arry which mean number should be smaller than collection number.
        if (_wayPoints.Count > 0 && _wayPoints[_currentWayPointID] != null)
        {
            _agent.SetDestination(_wayPoints[_currentWayPointID].position);
            float distance = Vector3.Distance(transform.position, _wayPoints[_currentWayPointID].position);
            if (distance < 1.0)
            {
                if (_currentWayPointID < _wayPoints.Count && _currentWayPointID +1 !=_wayPoints.Count)
                {
                    _currentWayPointID++;
                }
            }
        }
    }
}
