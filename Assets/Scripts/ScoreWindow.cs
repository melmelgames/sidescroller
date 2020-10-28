using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    public Text scoreText;
    private static ScoreWindow instance;

    private void Start()
    {
        instance = this;
        instance.Hide();
    }
    private void Update()
    {
        scoreText.text = "SCORE: " + Score.GetScore().ToString();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void ShowStatic()
    {
        instance.Show();
    }


}
