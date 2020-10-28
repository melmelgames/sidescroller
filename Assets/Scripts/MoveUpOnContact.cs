using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveUpOnContact : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb2d.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
    }
}
