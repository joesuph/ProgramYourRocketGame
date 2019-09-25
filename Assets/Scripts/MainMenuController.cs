using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void GoToGame()
    {
        print("Please load game");
        SceneManager.LoadScene(1);
    }


    public void quitGame(){
        print("I want to quit");
    }
}
