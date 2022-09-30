using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private Transform _myCamera;

    private void Start()
    {
        transform.position = _myCamera.position;
        transform.rotation = _myCamera.rotation;
    }

    void Update()
    {
        transform.LookAt(_player);
    }
}
