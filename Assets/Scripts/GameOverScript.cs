using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update

    // Restarts the game
    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameManager.isPaused = false;
        SceneManager.LoadScene("Shmup");
    }

    // Takes player back to main menu
    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameManager.isPaused = false;
        SceneManager.LoadScene("Menu");
    }

    // Ends the game
    public void EndGame()
    {
        Application.Quit();
    }

    // Resumes the game (Pause only)
    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameManager.isPaused = false;
    }

    // Pauses the game
    public void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameManager.isPaused = true;
    }
}
