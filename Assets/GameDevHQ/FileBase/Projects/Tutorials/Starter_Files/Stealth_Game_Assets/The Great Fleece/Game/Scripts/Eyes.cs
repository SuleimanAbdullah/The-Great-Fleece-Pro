using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    //Detect Daren when he collide with us
    //Enable game Over Cutscene
    [SerializeField]
    private GameObject _GameOverCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _GameOverCutscene.SetActive(true);
        }
    }
}
