using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    float carSpeed = 10F;
    float torqueForce = -2F;
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
    }

	void Update ()
    {

	}
}
