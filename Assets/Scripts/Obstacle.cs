using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Health.SubtractHealth();
            gameObject.SetActive(false);
        }
    }
}
