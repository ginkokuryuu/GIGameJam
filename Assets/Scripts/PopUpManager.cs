using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpManager : MonoBehaviour
{
    Scene curScene;

    void Start(){
        curScene = SceneManager.GetActiveScene();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(curScene.name);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        Debug.Log("Menu");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        Debug.Log("Next Level");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
