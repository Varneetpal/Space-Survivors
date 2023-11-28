using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    private float numberOfNotches;
    private float distanceBetweenNotches;
    private Vector3 positionOfNotch;
    [SerializeField] GameObject notch;

    public void SetMaxhealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        
    }

    void Start()
    {
        setNotches();   

    }

    public void setNotches()
    {
        destroyNotches();

        numberOfNotches = slider.maxValue / 10;
        distanceBetweenNotches = 1.2f / numberOfNotches;
        positionOfNotch = transform.position;
        positionOfNotch.x -= 0.6f;
        while (numberOfNotches > 1)
        {
            positionOfNotch.x += distanceBetweenNotches;
            Instantiate(notch, positionOfNotch, transform.rotation, this.transform);
            numberOfNotches -= 1;
        }

    }

    public void destroyNotches()
    {
        for(var i = transform.childCount -1; i > 0; i--)
        {
            Object.Destroy(transform.GetChild(i).gameObject);
        }
    }
}
