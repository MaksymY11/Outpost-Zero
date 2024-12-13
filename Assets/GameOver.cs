using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas; // Assign the GameOverCanvas in the Inspector

    public void ShowGameOverScreen()
    {
        gameOverCanvas.SetActive(true); // Enable the Game Over Canvas
        Time.timeScale = 0f; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    public void GoToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenuScene");
    }
}
