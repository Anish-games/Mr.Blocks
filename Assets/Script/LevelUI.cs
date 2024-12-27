using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public GameObject levelPanel;
    public TextMeshProUGUI levelText;
    public int levelNumber = 1;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button menuButton;

    public LevelManager levelManager;
    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = SoundManager.Instance;
    }

    private void Start()
    {
        UpdateLevelText();
        AddListeners();
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + levelNumber;
    }

    private void HideLevelPanel()
    {
        levelPanel.SetActive(false);
    }

    private void SetGameOverPanel(bool isActive)
    {
        gameOverPanel.SetActive(isActive);
        Debug.Log("Turned on the game over UI");
    }

    private void AddListeners()
    {
        restartButton.onClick.AddListener(RestartButton);
        menuButton.onClick.AddListener(MainMenuButton);
        Debug.Log("Restart button has activated");
        Debug.Log("Menu button has activated");
    }

    private void MainMenuButton()
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickAudio();
        }
        levelManager.LoadMainMenu();
        Debug.Log("level Menu");
    }

    private void RestartButton()
    {
        if (soundManager != null)
        {
            soundManager.PlayButtonClickAudio();
        }
        levelManager.RestartLevel();
        Debug.Log("level restarted");
    }

    public void ShowGameWinUI()
    {
        SetGameOverPanel(true);
        gameOverText.text = "Game Completed!!";
        gameOverText.color = Color.green;
        HideLevelPanel();
        Debug.Log("WIN");
        AddListeners();
        Debug.Log("Show Game win UI");
    }

    public void ShowGameLoseUI()
    {
        SetGameOverPanel(true);
        gameOverText.text = "Game Over!!";
        gameOverText.color = Color.red;
        HideLevelPanel();
        Debug.Log("loose");
        AddListeners();
    }
}
