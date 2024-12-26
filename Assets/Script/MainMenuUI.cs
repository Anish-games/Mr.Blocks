using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;


    private const int firstLevel = 1;  // Define the first level to load

    private void Awake()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }

    public void Play()
    {
        SceneManager.LoadScene(firstLevel);  // Load the first level
    }

    public void Quit()
    {
        Application.Quit();  // Quit the game
        Debug.Log("Game quit"); // Unity doesn't quit in the editor, so we log it
    }
}

