using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private Vector3 _targetPosition;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                _agent.destination = hitInfo.point;
                _animator.SetBool("isWalking", true);
                _targetPosition = hitInfo.point;
            }
        }

        float distance = Vector3.Distance(transform.position, _targetPosition);
        Debug.Log("distance checked :" + distance);
        if (distance < 1.0)
        {
            _animator.SetBool("isWalking", false);
        }
    }
}
