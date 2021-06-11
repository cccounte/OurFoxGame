using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float length, startpos;
    public GameObject cam;
    public float parallaxSpeed;

    void Start()
    {
        startpos = transform.position.x; 
    }

    void FixedUpdate()
    {   
        float dist = (cam.transform.position.x * parallaxSpeed);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

    }
}
