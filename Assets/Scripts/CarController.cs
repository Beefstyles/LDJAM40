using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    float carSpeed = 10F;
    float torqueForce = -200F;
    float driftFactorSticky = 0.9F;
    float driftFactorSlippy = 1F;
    float maxStickyVelocity = 2.5F;
    float minSlippyVelocity = 1.5F;

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
            // Consider using rb.AddForceAtPosition to apply fore twice at the position of the rear tyres
        }

        // If using positional wheel in phyis, then you probably want to add left/right force at the position of the front tyres proportional to your current forward speed
        float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 10);

        rb.angularVelocity = Input.GetAxis("Horizontal") * tf;

        float driftFactor = driftFactorSticky;
        if(RightVelocity().magnitude > maxStickyVelocity)
        {
            driftFactor = driftFactorSlippy;
        }

        

        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;
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
