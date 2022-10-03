using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    private bool _isVoiceOverPlayedOnce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _isVoiceOverPlayedOnce == false)
        {

            _audioSource.Play();
            _isVoiceOverPlayedOnce = true;
        }
    }
}
