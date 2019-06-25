using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 150f;
    public Rigidbody rb;
    public bool stop = false;

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
    }
}
