using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverCutScene;
    [SerializeField]
    private Animator _anim;

    private Renderer _render;

    private void Start()
    {
        _render = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _anim.enabled = false;
            _render.material.SetColor("_TintColor", new Color(.06f, 0, 0, 1));

            StartCoroutine(WaitBeforGameOverCutscene());
        }
    }

    IEnumerator WaitBeforGameOverCutscene()
    {
        yield return new WaitForSeconds(3f);
        _gameOverCutScene.SetActive(true);
    }
}
