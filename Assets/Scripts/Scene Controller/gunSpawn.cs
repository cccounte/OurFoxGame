using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSpawn : MonoBehaviour
{
   public GameObject gun;
   public Camera cam;

    void Update()
    {   
        SpawnGun();
    }

    void SpawnGun(){
        if(Input.GetButtonDown("Fire2")){
            Instantiate(gun, new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.identity);
        }
    }
}
