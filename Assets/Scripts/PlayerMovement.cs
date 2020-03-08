using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D playerRigidbody;
    private Vector3 changepos;
    private bool facingRight = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        changepos = Vector3.zero;
        changepos.x = Input.GetAxisRaw("Horizontal");
        changepos.y = Input.GetAxisRaw("Vertical");
        if (Input.GetAxisRaw("Horizontal") > 0.5f && !facingRight)
        {
            //If we're moving right but not facing right, flip the sprite and set     facingRight to true.
            Flip();
            facingRight = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0.5f && facingRight)
        {
            //If we're moving left but not facing left, flip the sprite and set facingRight to false.
            Flip();
            facingRight = false;
        }
        UpdateAnimation();
        

    }

    private void UpdateAnimation()
    {
        if (changepos != Vector3.zero)
        {
            MoveChar();
            animator.SetFloat("moveX", changepos.x);
            animator.SetFloat("moveY", changepos.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    private void MoveChar()
    {
        playerRigidbody.MovePosition(
                transform.position + changepos*speed*Time.deltaTime
            );
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
