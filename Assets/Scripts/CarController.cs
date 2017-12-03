using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    float carSpeed = 10F;
    float brakingForce = 5F;
    float torqueForce = -200F;
    float driftFactorSticky = 0.9F;
    float driftFactorSlippy = 1F;
    float maxStickyVelocity = 2.5F;
    float minSlippyVelocity = 1.5F;

    public AudioClip[] EngineSounds;
    public AudioClip[] WallHitSounds;
    public AudioSource engineController;
    public AudioSource wallHitController;

    public 

    public GameObject FrontLeftTyre, FrontRightTyre, RearLeftTyre, RearRightTyre;

    Rigidbody2D rb;


    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        engineController.loop = true;
    }

    void ChangeSoundOnSpeed()
    {
        if(rb.velocity.magnitude >= (carSpeed * 2) / 1.5)
        {
            engineController.clip = EngineSounds[5];
        }
        else if (rb.velocity.magnitude >= (carSpeed * 2) / 2)
        {
            engineController.clip = EngineSounds[4];
        }

        else if (rb.velocity.magnitude >= (carSpeed * 2) / 2.5)
        {
            engineController.clip = EngineSounds[3];
        }

        else if (rb.velocity.magnitude >= (carSpeed * 2) / 3)
        {
            engineController.clip = EngineSounds[2];
        }

        else if (rb.velocity.magnitude >= (carSpeed * 2) / 3.5)
        {
            engineController.clip = EngineSounds[1];
        }

        else
        {
            engineController.clip = EngineSounds[0];
        }
        Debug.Log(rb.velocity.magnitude);

        if (!engineController.isPlaying)
        {
            engineController.Play();
        }
    }

    void Update()
    {
        ChangeSoundOnSpeed();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        int randomNoise = Random.Range(0, WallHitSounds.Length);
        wallHitController.clip = WallHitSounds[randomNoise];
        if (!wallHitController.isPlaying)
        {
            wallHitController.Play();
        }
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
            float brakeForce = 0;
            if(rb.velocity.magnitude <= 0)
            {
                brakeForce = 1F;
            }
            else
            {
                brakeForce = brakingForce;
            }
            rb.AddForceAtPosition(-transform.up * brakeForce, FrontLeftTyre.transform.position);
            rb.AddForceAtPosition(-transform.up * brakeForce, FrontRightTyre.transform.position);
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
