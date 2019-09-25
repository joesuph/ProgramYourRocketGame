using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuHandler : MonoBehaviour
{
    private Canvas pauseCanvas;
    private bool isOpen = false;

    private void Awake()
    {
        pauseCanvas = GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePauseMenu();
    }

    private void ShowPauseMenu()
    {
        //pauseCanvas.SetActive(true);
        pauseCanvas.enabled = true;
        Time.timeScale = 0f;
        isOpen = true;
    }
    private void HidePauseMenu()
    {
        //pauseCanvas.SetActive(false);
        pauseCanvas.enabled = false;
        Time.timeScale = 1f;
        isOpen = false;
    }

    private void TogglePauseMenu()
    {
        print("Toggling");

        if (isOpen)
            HidePauseMenu();
        else
            ShowPauseMenu();
    }
    
    public void goToMenu()
    {
        print("This worked kinda");
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        HidePauseMenu();
    }

}
