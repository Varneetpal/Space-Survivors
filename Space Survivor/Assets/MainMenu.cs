using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject creditPage;
    public GameObject settingPage;

    public void Start()
    {
        menu.SetActive(true);
        creditPage.SetActive(false);
        settingPage.SetActive(false);
    }

    public void playGame()
    {
        SceneManager.LoadScene("TopDown Shooter");
    }

    public void creditOpen() {
        menu.SetActive(false);
        creditPage.SetActive(true);
    }

    public void creditClose()
    {
        creditPage.SetActive(false);
        menu.SetActive(true);
    }

    public void settingOpen()
    {
        menu.SetActive(false);
        settingPage.SetActive(true);
    }

    public void settingClose()
    {
        settingPage.SetActive(false);
        menu.SetActive(true);
    }


    public void quitGame()
    {
        Application.Quit();
    }
}
