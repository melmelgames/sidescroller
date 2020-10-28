using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{

    private float initPosY;
    [SerializeField] private float speed;
    [SerializeField] private float amplitude;
    [SerializeField] private bool movingUp;
    private void Awake()
    {
        initPosY = gameObject.transform.position.y;
        movingUp = false;
        
    }

    private void Update()
    {
        MovingUpDown();
    }

    private void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        movingUp = true;
    }

    private void MoveDown()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime, Space.World);
        movingUp = false;
    }

    private void MovingUpDown()
    {
        switch (movingUp)
        {
            case true:
                if (transform.position.y >= initPosY + amplitude)
                {
                    MoveDown();
                }
                else
                {
                    MoveUp();
                }
                break;
            case false:
                if (transform.position.y <= initPosY - amplitude)
                {
                    MoveUp();
                }
                else
                {
                    MoveDown();
                }
                break;
        }
    }
}
