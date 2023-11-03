using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void Start()
    {
        
    }

    public void playAgain()
    {
        SceneManager.LoadScene("TopDown Shooter");
    }

    public void mainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
