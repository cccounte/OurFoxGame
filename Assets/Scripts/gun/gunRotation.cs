using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunRotation : MonoBehaviour
{
    //Components
    public Rigidbody2D rb;
    Camera cam;

    //Vectors
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        cam = GameObject.Find("MainCam").GetComponent<Camera>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate() {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
