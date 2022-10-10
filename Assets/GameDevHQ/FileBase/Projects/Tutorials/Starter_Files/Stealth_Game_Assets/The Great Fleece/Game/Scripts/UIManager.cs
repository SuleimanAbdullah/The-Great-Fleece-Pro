using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get 
        {
            if (_instance ==null)
            {
                Debug.LogError(" UI Manager is NULL:");
            }
            return _instance;
        }
    }

    [SerializeField]
    private int _sceneIndex;

    private void Awake()
    {
        _instance = this;
    }

    public void Restart()
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
