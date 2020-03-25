using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform tf; // A variable to hold our Transform component
    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    private Animator anim;

    public float jumpForce = 3.5f;
    public float speed = 5.0f; // a speed variable that designers can change in unity
    public bool isGrounded = false;
    public Transform groundPoint;
    void Start()
    {
        tf = GetComponent<Transform>(); // gets the transform to use for movement
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {    //walk
        float xMovemoent = Input.GetAxis("Horizontal") * speed;

        rb2d.velocity = new Vector2(xMovemoent,rb2d.velocity.y);

        sr.flipX = rb2d.velocity.x < 0;
        if (xMovemoent > 0)
        {
            sr.flipX = false;
            anim.Play("Run_player");
        }
        else if(xMovemoent < 0)
        {
            sr.flipX = true;
            anim.Play("Run_player");
        }
        else
        {
            anim.Play("Player_idle");
        }
        //checking for isGrounded bool
        
        RaycastHit2D hitInfo = Physics2D.Raycast(groundPoint.position, Vector2.down, 0.1f);
        if (hitInfo.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        //working with animation transitons
        if (xMovemoent == 0.0f)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        //jump and trying to only play animation when space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.AddForce((Vector2.up * jumpForce));
            anim.SetBool("isGrounded", false);
        }
        else
        {
            anim.SetBool("isGrounded", true);
        }

        if (anim.GetBool("isGrounded") == false)
        {
            anim.Play("Player_jump");
        }
    }
}