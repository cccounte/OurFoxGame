using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapSapwnMagus : MonoBehaviour
{
    public GameObject magusVfx;
    public Transform magusSpawner;
    public GameObject backMusic;
    public GameObject backMusic2;
    AudioSource AudioHappy;
    AudioSource AudioSuspense;

    void Start(){
        AudioHappy = backMusic.GetComponent<AudioSource>();
        AudioSuspense = backMusic2.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            Instantiate(magusVfx, new Vector3(magusSpawner.position.x, magusSpawner.position.y, 0), magusSpawner.rotation);
            Destroy(gameObject);
            AudioHappy.Stop();
            AudioSuspense.Play();
        }  
    }
}
