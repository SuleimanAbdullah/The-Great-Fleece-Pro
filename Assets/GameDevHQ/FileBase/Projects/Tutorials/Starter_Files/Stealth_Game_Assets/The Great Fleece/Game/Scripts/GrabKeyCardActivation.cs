using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _sleepingGuardCutScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _sleepingGuardCutScene.SetActive(true);
        }
    }
}
