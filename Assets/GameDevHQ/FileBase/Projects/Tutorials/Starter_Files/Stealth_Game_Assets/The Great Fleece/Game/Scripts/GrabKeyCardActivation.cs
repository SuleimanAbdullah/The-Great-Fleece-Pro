using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _sleepingGuardCutScene;
    private bool _isCutSceneActivatedOnce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _isCutSceneActivatedOnce == false)
        {
            _sleepingGuardCutScene.SetActive(true);
            _isCutSceneActivatedOnce = true;
            GameManager.Instance.HasCard = true;
        }
    }
}
