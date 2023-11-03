using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : MonoBehaviour
{

    public GameObject UiMessage;
    // Start is called before the first frame update
    void Start()
    {
        UiMessage.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        UiMessage.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        UiMessage.SetActive(false);

    }
}
