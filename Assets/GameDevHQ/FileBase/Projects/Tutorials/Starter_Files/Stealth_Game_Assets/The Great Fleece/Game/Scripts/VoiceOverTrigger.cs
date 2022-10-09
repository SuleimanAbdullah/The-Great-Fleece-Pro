using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clipToPlay;
    private bool _isVoiceOverPlayedOnce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _isVoiceOverPlayedOnce == false)
        {

            AudioManager.Instance.PlayVoiceOver(_clipToPlay);
            _isVoiceOverPlayedOnce = true;
        }
    }
}
