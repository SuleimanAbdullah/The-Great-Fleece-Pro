using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    // Start is called before the first frame update
    void Update()
    {
        transform.LookAt(_player);
    }

}
