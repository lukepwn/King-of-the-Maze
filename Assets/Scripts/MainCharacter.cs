using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{

    private bool facingRight = true;
    public float speed = 5f;
    //public float jumpforce = 5f;
    public Vector2 move;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        InputMovement();
        AnimationMovement();
        SpriteDirection();
    }

    void InputMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(moveX, moveY) * speed;

        // if input = spacebar, do jump vertical vector * jump value 
        // if (Input.GetKeyDown("space"))
        // {
        //     print("space");
        //     rb.velocity = Vector2.up * jumpforce;
        // }
    }

    void SpriteDirection()
    {
        // if horizontal.x < 0, look right 
        // else, return

        if ((rb.velocity.x < 0f && facingRight) || (rb.velocity.x > 0f && !facingRight))
            if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
                facingRight = !facingRight;
                transform.Rotate(new Vector3(0, 180, 0));
            }

    }
    void AnimationMovement()
    {
        // if no keys are being press (VELOCITY = 0), then play idle 
        // if press x, play attack animation 

        // look up advanced if statements later

        // if (move = 0 )
        // {
        //     animator.setBool("")
        // }


        if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("ATTACK", true);
        }

        else
        {
            animator.SetBool("ATTACK", false);
        }
    }


}
