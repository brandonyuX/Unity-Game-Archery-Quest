using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Tutorial()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void MainScreen()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
