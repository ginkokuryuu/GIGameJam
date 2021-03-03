using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int levelCount = 1;

    public void PlayTheGame()
    {
        UnityEngine.Random.InitState((DateTime.Now.ToString("hh:mm:ss")).GetHashCode());
        int level = UnityEngine.Random.Range(1, levelCount - 1);
        string levelName = "Level " + level.ToString();
        StartCoroutine(LoadScene(levelName));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }

    IEnumerator LoadScene(string scene)
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(scene);
        while (!loadScene.isDone)
        {
            yield return null;
        }
    }

    public void MainMenu()
    {
        StartCoroutine(LoadScene("MainMenu"));
    }
}
