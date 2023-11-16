using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject creditPage;
    [SerializeField] public GameObject player;
    public void Start()
    {

        player.SetActive(false);
        menu.SetActive(true);
        creditPage.SetActive(false);
    }

    public void playGame()
    {
        SceneManager.LoadScene("TopDown Shooter");
        player.SetActive(true);
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
    
    public void toggleAllSound()
    {
        AudioListener.volume = Mathf.Abs(AudioListener.volume - 1);
    }

    public void UnMuteAllSound()
    {
        AudioListener.volume = 1;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
