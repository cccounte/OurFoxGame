using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //andar
    float horizontal;
    public float speed;
    Animator anim;
    bool isRunning;
    float rbVelocityX;


    //Jumps
    public float jumpForce;
    public bool canJump = false;
    public bool isGrounded;
    bool caindo;

    //Components
    Rigidbody2D rb;
    Transform tr;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        Jump();
        
    }

    void FixedUpdate()
    {
        walkController();
        if(rb.velocity.y != 0){
            canJump = false;
            isGrounded = false;
        }

    }
    

    void walkController(){

        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        spriteController();
    }

    void spriteController(){

        anim.SetBool("isRunning", isRunning);
        anim.SetFloat("vSpeed", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);

        rbVelocityX = rb.velocity.x;

         if(rbVelocityX != 0){
            tr.localScale = new Vector2(horizontal, tr.localScale.y);
            isRunning = true;
        }else{
            isRunning = false;
        }


    }


    void Jump(){

        if(Input.GetButtonDown("Jump") && canJump  == true){
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            canJump  = false;
        } 
    }

    void OnCollisionEnter2D(Collision2D  other){
        if(other.gameObject.tag == "Ground"){
            canJump = true;
            isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D other) {
         if(other.gameObject.tag == "Ground"){
            canJump = true;
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D  other){
        if(other.gameObject.tag == "Ground"){
            canJump = false;
            isGrounded = false;
        }
    }
}