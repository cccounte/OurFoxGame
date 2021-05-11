using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //andar
    public float speed;


    //Jumps
    public float jumpForce;
    public bool canJump = false;

    //Components
    Rigidbody2D rb;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //andar
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
    }

    void Update(){
        //pular
        if(Input.GetButtonDown("Jump") && canJump  == true){
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            canJump  = false;
        }
    }

    void OnCollisionEnter2D(Collision2D  other){
        if(other.gameObject.tag == "Ground"){
            canJump = true;
        }
    }
}
