using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public Animator playerAnimator;
    
    private Rigidbody2D rb2D;
    [SerializeField] private float jumpForce;
    [SerializeField] private float dashDistance;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isDoubleJumping;
    [SerializeField] private float doubleJumpWindow; // how hard it is to time a double jump

    private void Awake(){
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        isJumping = false;
        isDoubleJumping = false;
    }

    private void Update(){
        ManagePlayerInput();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Collectable")
        {
            Score.AddScore(col.GetComponent<Collectable>().GetValue());
            Destroy(col.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        // Makes sure the player is not allowed infinite consecutives mid air jumps
        if (collision.gameObject.tag == "Floor") {
            isJumping = false;
            isDoubleJumping = false;
            playerAnimator.SetBool("jumpBool", false);
            playerAnimator.SetTrigger("runTrigger");
        }

        // Game over?
        if (collision.gameObject.tag == "gameOverBoundary")
        {
            GameManager.GameOverStatic();
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            playerAnimator.SetTrigger("hitTrigger");
        }
    }

    private void ManagePlayerInput(){
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // JUMP
            if (touch.phase == TouchPhase.Ended && !isJumping)
            {
                rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
                playerAnimator.SetBool("jumpBool", true);
            }
            // DOUBLE-JUMP
            float vy = Mathf.Abs(rb2D.velocity.y);
            if (touch.phase == TouchPhase.Ended && isJumping && !isDoubleJumping && vy < doubleJumpWindow)
            {
                rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                isDoubleJumping = true;
                playerAnimator.SetTrigger("doubleJumpTrigger");
            }
        }

    }
}
