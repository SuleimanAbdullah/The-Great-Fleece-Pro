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
    private Animator _animator;
    public bool _isCoinTossed;
    public Vector3 _coinPos;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        if (_animator != null)
        {
            _animator.SetBool("isWalking", true);
        }
    }

    void Update()
    {
        if (_wayPoints.Count > 0 && _wayPoints[_currentWayPointID] != null && _isCoinTossed == false)
        {
            _agent.SetDestination(_wayPoints[_currentWayPointID].position);
            float distance = Vector3.Distance(transform.position, _wayPoints[_currentWayPointID].position);
           
            if (distance < 1.0 && (_currentWayPointID == 0 || _currentWayPointID == _wayPoints.Count - 1))
            {
                _animator.SetBool("isWalking", false);

            }
            else
            {
                _animator.SetBool("isWalking", true);
            }

            if (distance < 1.0 && _targetReached == false )
            {
                _targetReached = true;
                StartCoroutine(WaitBeforeMoving());
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, _coinPos);
            if (distance < 4)
            {
                _agent.stoppingDistance = 4;
                _animator.SetBool("isWalking", false);
                StartCoroutine(WaitBeforeResetAIPatrol());
            }
        }
    }

    private IEnumerator WaitBeforeMoving()
    {
        if (_isReversing == false)
        {

            if (_currentWayPointID == 0)
            {
                yield return new WaitForSeconds(Random.Range(2f, 6f));
            }

            _currentWayPointID++;

            if (_currentWayPointID == _wayPoints.Count)
            {
                _currentWayPointID -= 1;
                yield return new WaitForSeconds(Random.Range(2f, 6f));
                _isReversing = true;
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

    IEnumerator WaitBeforeResetAIPatrol()
    {
        yield return new WaitForSeconds(Random.Range(15, 18f));
        _isCoinTossed = false;
        _agent.stoppingDistance = 0;
    }
}
