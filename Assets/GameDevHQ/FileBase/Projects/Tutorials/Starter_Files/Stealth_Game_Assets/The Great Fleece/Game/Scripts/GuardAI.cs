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
    private bool _targetReached;
    [SerializeField]
    private bool _isReversing;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_wayPoints.Count > 0 && _wayPoints[_currentWayPointID] != null)
        {
            _agent.SetDestination(_wayPoints[_currentWayPointID].position);
            float distance = Vector3.Distance(transform.position, _wayPoints[_currentWayPointID].position);

            if (distance < 1.0 && _targetReached == false)
            {
                _targetReached = true;
                StartCoroutine(WaitBeforeMoving());
            }
        }
    }

    private IEnumerator WaitBeforeMoving()
    {

        //stop a point a
        //and stop at point c 
        if (_isReversing == false)
        {
            if (_currentWayPointID == 0)
            {
                yield return new WaitForSeconds(Random.Range(2f, 5f));
            }
            _currentWayPointID++;
            if (_currentWayPointID == _wayPoints.Count)
            {
                _currentWayPointID = 2;
                _isReversing = true;
                yield return new WaitForSeconds(Random.Range(2f, 5f));
            }
        }

        if (_isReversing == true)
        {
            _currentWayPointID--;
            if (_currentWayPointID < 0)
            {
                _currentWayPointID = 0;
                _isReversing = false;
            }
        }
        _targetReached = false;
    }
}
