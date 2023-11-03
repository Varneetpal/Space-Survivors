using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleport : MonoBehaviour
{

    [SerializeField] private Animator animationController;

    public GameObject UiMessage;

    private void Start()
    {
        UiMessage.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        UiMessage.SetActive(true);
        //if player is standing on telporter start animation 
        if (other.CompareTag("Player"))
        {
            animationController.SetBool("playTeleport", true);
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        UiMessage.SetActive(false);
        if (other.CompareTag("Player"))
        {
            animationController.SetBool("playTeleport", false);
        }
    }
}
