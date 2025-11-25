using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isGameOver = false;

    public GameObject gameOverPanel;
    public GameObject gameWinPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void WinGame()
    {
        if (isGameOver) return;

        isGameOver = true;
        AudioManager.Instance.WinSound();
        gameWinPanel.SetActive(true);
        Invoke(nameof(LoadNextLevel), 2f);
    }

    public void LoseGame()
    {
        if (isGameOver) return;

        isGameOver = true;
        AudioManager.Instance.LoseSound();
        gameOverPanel.SetActive(true);
        Invoke(nameof(RestartLevel), 2f);
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
