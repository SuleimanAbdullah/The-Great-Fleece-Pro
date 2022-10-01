using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private Vector3 _targetPosition;
    [SerializeField]
    private GameObject _coinPrefab;
    private bool _isCoinTossed;


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
        if (distance < 1.0)
        {
            _animator.SetBool("isWalking", false);
        }

        //if right click
        //Instantiate a coin at mouse position
        //play sound for coin effect for coin drop

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Button Pressed: ");
            RaycastHit hitInfo;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out hitInfo))
            {
                if (_isCoinTossed ==false)
                {
                    Instantiate(_coinPrefab, hitInfo.point, Quaternion.identity);
                    _isCoinTossed = true;
                }
                
            }
        }
    }
}
