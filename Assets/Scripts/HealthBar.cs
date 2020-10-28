using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;


    // Update is called once per frame
    void Update()
    {
        int health = Health.GetHealth();
        switch (health)
        {
            case 3:
                //do
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
            case 2:
                //do
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                break;
            case 1:
                //do
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 0:
                //do
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
        }
    }
}
