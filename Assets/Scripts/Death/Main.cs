using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public bool Walking;
    public float speed;
    public float distanceToAttack;

    bool p;

    Animator anim;
    Rigidbody2D rb;
    GameObject Gamer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Gamer = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        
        anim.SetBool("Walking", Walking);

        //g
        if((transform.position.x - Gamer.transform.position.x) < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            goToPlayer(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Mudar depois
        if(collision.gameObject.tag == "Player")
        {
            Walking = false;
        }
    }

    void goToPlayer(GameObject player)
    {
        Transform playerTransform = player.transform;
        Vector2 target = new Vector2(playerTransform.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        float distance = Vector3.Distance(rb.position, playerTransform.position);

        if (distance < distanceToAttack)
        {
            anim.SetTrigger("Attack");
            Walking = false ;
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.MovePosition(newPos);
            Walking = true;
        }
    }

}
