using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public LevelUI levelUI;
    private int currentSceneIndex;
    private const int mainMenuIndex = 0;

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.Instance;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        soundManager.PlayBackgroundMusic();
    }

    public void OnLevelComplete()
    {
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = currentSceneIndex + 1;
        int totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;

        if (nextSceneIndex < totalNumberOfScenes)
        {
            SceneManager.LoadScene(nextSceneIndex);
            Debug.Log("Next Level get load");
        }
        else
        {
            levelUI.ShowGameWinUI();
            Debug.Log("showing wining screen");
        }
    }

    public void OnPlayerDeath()
    {
        levelUI.ShowGameLoseUI();
        Debug.Log("calling the function of show loose UI");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
        Debug.Log("Restarted the level");
    }

    public void LoadMainMenu() => SceneManager.LoadScene(mainMenuIndex);
}
