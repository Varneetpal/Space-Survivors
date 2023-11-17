using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class teleport : MonoBehaviour
{

    [SerializeField] private Animator animationController;

    public GameObject UiMessage;

    private bool inCollision = false;

    private void Start()
    {
        UiMessage.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        inCollision = true;
        UiMessage.SetActive(true);
        //if player is standing on telporter start animation 
        if (other.CompareTag("Player"))
        {
            animationController.SetBool("playTeleport", true);
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        inCollision = false;
        UiMessage.SetActive(false);
        if (other.CompareTag("Player"))
        {
            animationController.SetBool("playTeleport", false);
        }
    }

    private void Update()
    {
        if (inCollision && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAudioManager.instance.PlaySound("Teleport");
            GameManager.instance.loadShooterScene();
        }
    }
}
