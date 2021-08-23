using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public bool Walking;
    public float speed;
    public float distanceToAttack;


    Animator anim;
    Rigidbody2D rb;
    GameObject Gamer;

    Vector3 previous;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Gamer = GameObject.FindGameObjectWithTag("Player");

    }

    void FixedUpdate()
    {
        SpriteController();
    }

    //SPRITE CONTROLLER =============================================================

    void SpriteController()
    {
        anim.SetBool("Walking", Walking);

        Vector3 vel = (transform.position - previous) / Time.fixedDeltaTime;
        previous = transform.position;

        if ((transform.position.x - Gamer.transform.position.x) < 0) Flip(-1);
        else Flip(1);

        Walking = vel.x != 0;

    }

    void Flip(int newX)
    {
        transform.localScale = new Vector2(newX, transform.localScale.y);
    }

    //GO TO PLAYER ====================================================================

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GoToPlayer(collision.gameObject);
        }
    }

    void GoToPlayer(GameObject player)
    {
        Transform playerTransform = player.transform;
        Vector2 target = new Vector2(playerTransform.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        float distance = Vector3.Distance(rb.position, playerTransform.position);

        if (distance < distanceToAttack)
        {
            anim.SetTrigger("Attack");
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            rb.MovePosition(newPos);
        }
    }

}
