using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        //if left click
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            //cast a ray from mouse position
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //debug the floor position hit
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log(hitInfo.point);
                _agent.destination = hitInfo.point;
            }
        }
    }
}
