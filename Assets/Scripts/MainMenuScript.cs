using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    void Awake()
    {
        Screen.SetResolution(768, 1024, true); // Sets the resolution
    }

    // Click play
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    // Click quit
    public void QuitButton()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
    
}
