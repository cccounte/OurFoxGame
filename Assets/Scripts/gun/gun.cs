using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    //components
    Transform gunTransform;
    Transform tr;

    public Rigidbody2D rb;
    Vector2 mousePos;
    public Camera cam;


    //Objetos
    public GameObject bullet;
    public Transform spawn;

    //outros
    public float bulletForce = 500f;

    private void Awake() {
        gunTransform = transform.Find("TommyGun");
        spawn = transform.Find("spawnPoint");
        tr = GetComponent<Transform>();
    }
    void Update()
    {   
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        gunRotation();
        gunShoot();
    }

    void gunRotation(){
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void gunShoot(){
        if(Input.GetButtonDown("Fire1")){
            Instantiate(bullet, spawn.position, spawn.rotation);
        }
    }
}
