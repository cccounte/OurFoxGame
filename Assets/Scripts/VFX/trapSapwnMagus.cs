using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapSapwnMagus : MonoBehaviour
{
    public GameObject magusVfx;
    public Transform magusSpawner;

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.tag == "Player"){
    //         Instantiate(magusVfx, magusSpawner.position, magusSpawner.rotation);
    //         Destroy(gameObject);
    //     }    
    // }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            Instantiate(magusVfx, new Vector3(magusSpawner.position.x, magusSpawner.position.y, 0), magusSpawner.rotation);
            Destroy(gameObject);
        }  
    }
}
