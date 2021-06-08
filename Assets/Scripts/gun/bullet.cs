using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject spawn;
    public float bulletForce = 50f;


    Transform str;
    Rigidbody2D rb;
    Transform tr;

    float x;
    void Start()
    {   
        spawn = GameObject.Find("TommyGun");
        str = spawn.GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        go();
    }

    void Update(){
        Debug.Log(str.up);
    }

    void go()
    {
        rb.AddForce( new Vector2(str.up.x * 52, str.up.y * 52));
    }

    
}
