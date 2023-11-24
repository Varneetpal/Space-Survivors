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
        GameManager.instance.restartGame();
    }

    public void mainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
