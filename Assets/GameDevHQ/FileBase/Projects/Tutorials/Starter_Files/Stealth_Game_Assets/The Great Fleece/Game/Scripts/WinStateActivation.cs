using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _WinCutScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance !=null)
            {
                if (GameManager.Instance.HasCard == true)
                {
                    _WinCutScene.SetActive(true); 
                }
                else
                {
                    Debug.Log("Find the key");
                }
            }
            
        }
    }
}
