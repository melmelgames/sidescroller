using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float initPosY;
    [SerializeField] private float force;
    [SerializeField] private float floatingAmplitude;

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        initPosY = gameObject.transform.position.y;
    }

    private void FixedUpdate()
    {
        if(transform.position.y >= initPosY + floatingAmplitude)
        {
            rb2D.AddForce(-transform.up * force);
        }
        else if (transform.position.y <= initPosY - floatingAmplitude)
        {
            rb2D.AddForce(transform.up * force);
        }
        
    }


}
