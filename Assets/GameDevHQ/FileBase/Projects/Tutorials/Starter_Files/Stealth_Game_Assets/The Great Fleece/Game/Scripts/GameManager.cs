using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("The GameManager is NULL:");
            }
            return _instance;
        }
    }

    public bool HasCard { get; set; }

    [SerializeField]
    private PlayableDirector _introCutScene;

    private void Awake ()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _introCutScene.time = 59.1f;
            Debug.Log(KeyCode.S.ToString() + " Key Pressed");
        }
    }
}
