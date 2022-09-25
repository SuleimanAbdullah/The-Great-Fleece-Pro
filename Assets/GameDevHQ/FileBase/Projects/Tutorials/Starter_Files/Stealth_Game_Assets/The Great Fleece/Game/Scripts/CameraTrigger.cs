using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _cameraProgresionAngle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Camera.main.transform.position = _cameraProgresionAngle.transform.position;
            Camera.main.transform.rotation = _cameraProgresionAngle.transform.rotation;
        }
    }
}
