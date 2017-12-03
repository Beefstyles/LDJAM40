using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    float carSpeed = 10F;
    float torqueForce = -2F;
    float driftFactor = 0.9F;
    Rigidbody2D rb;


    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	

    void FixedUpdate()
    {
        if (Input.GetButton("Accelerate"))
        {
            rb.AddForce(transform.up * carSpeed);
        }

        rb.AddTorque(Input.GetAxis("Horizontal") * torqueForce);

        rb.velocity = ForwardVelocity() + RightVelocity()*driftFactor;
    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(rb.velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(rb.velocity, transform.right);
    }

}
