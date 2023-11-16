using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseFireratre : MonoBehaviour
{
    private bool inCollision = false;
    public GameObject UiMessage;
    // Start is called before the first frame update
    void Start()
    {
        UiMessage.SetActive(false);
    }
    private void Update()
    {
        if (inCollision && Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.upgradeFireRate();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inCollision = true;
        UiMessage.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        inCollision = false;
        UiMessage.SetActive(false);

    }
}
