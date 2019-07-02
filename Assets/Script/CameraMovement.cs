using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 150f;
    public Rigidbody rb;
    public bool stop = false;
    public float dif = 27.15f;
    public GameObject bg;

    void Update()
    {
        if(!stop)
        {
            rb.velocity = new Vector3(speed * Time.fixedDeltaTime, rb.velocity.y, rb.velocity.z);
        }
        else if (stop)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

        if(this.transform.position.x >= dif)
        {
            bg.transform.position = new Vector3(bg.transform.position.x + 19.15f, bg.transform.position.y, bg.transform.position.z);
            dif += 19.15f;
        }
    }
}
