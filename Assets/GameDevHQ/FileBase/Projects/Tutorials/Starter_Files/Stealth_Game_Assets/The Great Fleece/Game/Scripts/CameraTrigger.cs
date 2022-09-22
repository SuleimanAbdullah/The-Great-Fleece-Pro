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
            Debug.Log("Trigger Activated:");
            //camera main position = camerprogressionangle position
            //camer main rotation = cameraprogretion rotation
            Camera.main.transform.position = _cameraProgresionAngle.transform.position;
            Camera.main.transform.rotation = _cameraProgresionAngle.transform.rotation;

        }
    }
}
