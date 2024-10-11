using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuScreen : MonoBehaviour
{
    public GameObject gameTitleCanvas;  // Reference to the Game Title Canvas
    public GameObject storylineCanvas;  // Reference to the Storyline Canvas
    
    public float delayBeforeMenu = 5f;  // Delay before loading Main Menu Scene

    private void Start()
    {
       // gameTitleCanvas.SetActive(true);
       // storylineCanvas.SetActive(false);
    }

    public void LoadGame()
    {
        // Hide the Game Title Canvas and show the Storyline Canvas
        gameTitleCanvas.SetActive(false);
        storylineCanvas.SetActive(true);
    }
   

    public void Play()
    {
        // Load the game scene directly if "Play" is selected
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void LoadMainMenuAfterStoryline()
    {
        StartCoroutine(WaitAndLoadMainMenu());
    }

    private IEnumerator WaitAndLoadMainMenu()
    {
        // Wait for the delay time, then load the main menu scene
        yield return new WaitForSeconds(delayBeforeMenu);
        SceneManager.LoadScene("MainMenu Scene");
    }
}
