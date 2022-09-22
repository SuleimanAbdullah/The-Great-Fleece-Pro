using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;

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

            //debug the floor position hit
            if (Physics.Raycast(ray, out hitInfo))
            {
                _agent.destination = hitInfo.point;
                _animator.SetBool("isWalking", true);
            }

        }
        else if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _animator.SetBool("isWalking", false);
        }

    }
}
