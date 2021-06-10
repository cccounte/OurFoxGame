using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateMagus : MonoBehaviour
{
    public GameObject magus;

    public void InvokeMagus(){
        Instantiate(magus, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
