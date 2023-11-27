using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        //menu.SetActive(false);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                unpauseGame();
            }
            else
            {
                pauseGame();
            }
        }
    }
    
    public void backToGame()
    {
        unpauseGame();
    }

    public void mainMenu()
    {
        Time.timeScale = 1;
        paused = false;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void toggleAllSound()
    {
        AudioListener.volume = Mathf.Abs(AudioListener.volume - 1);
    }
    
    public void quitGame()
    {
        Application.Quit();
    }

    private void pauseGame()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        paused = true;
    }

    private void unpauseGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }
}
