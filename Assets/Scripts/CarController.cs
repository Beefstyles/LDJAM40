using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    float carSpeed = 5F;
    float brakingForce = 2F;
    float torqueForce = -200F;
    float driftFactorSticky = 0.9F;
    float driftFactorSlippy = 1F;
    float maxStickyVelocity = 2.5F;
    float minSlippyVelocity = 1.5F;

    public GameObject FrontLeftTyre, FrontRightTyre, RearLeftTyre, RearRightTyre;

    Rigidbody2D rb;


    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	

    void FixedUpdate()
    {
        if (Input.GetButton("Accelerate"))
        {
            //rb.AddForce(transform.up * carSpeed);
            rb.AddForceAtPosition(transform.up * carSpeed, RearLeftTyre.transform.position);
            rb.AddForceAtPosition(transform.up * carSpeed, RearRightTyre.transform.position);
        }

        if (Input.GetButton("Brakes"))
        {
            rb.AddForceAtPosition(-transform.up * brakingForce, FrontLeftTyre.transform.position);
            rb.AddForceAtPosition(-transform.up * brakingForce, FrontRightTyre.transform.position);
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
