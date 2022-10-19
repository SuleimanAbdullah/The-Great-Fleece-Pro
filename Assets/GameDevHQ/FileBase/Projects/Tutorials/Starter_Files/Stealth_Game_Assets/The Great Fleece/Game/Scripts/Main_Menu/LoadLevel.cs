using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // reference to progress bar

    [SerializeField]
    private Image _progressBar;

    void Start()
    {
        //call coroutine to load Main Scene
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        //create asyncoperation = LoadLevelAsync("Main")
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");
        //while ooperation is not finished
        while (operation.isDone == false)
        {
            _progressBar.fillAmount = operation.progress;
            yield return new WaitForEndOfFrame();
        }
          //progress bar fill amount = operaton progress
          //wait end of the frame
    }
}
