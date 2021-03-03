using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayTheGame()
    {
        StartCoroutine(LoadScene("Main"));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadScene(string scene)
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(scene);
        while (!loadScene.isDone)
        {
            yield return null;
        }
    }
}
