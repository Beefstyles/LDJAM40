using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    float carSpeed = 3F; // Default 10F
    float brakingForce = 1F; // Default 5F
    float torqueForce = -50F; // Default -200F
    float driftFactorSticky = 0.8F; // Default 0.9F
    float driftFactorSlippy = .99F;
    float maxStickyVelocity = 4F; //2.5
    float minSlippyVelocity = 1.5F;

    public AudioClip[] EngineSounds;
    public AudioClip[] WallHitSounds;
    public AudioSource engineController;
    public AudioSource wallHitController;
  

    public GameObject FrontLeftTyre, FrontRightTyre, RearLeftTyre, RearRightTyre;

    Rigidbody2D rb;

    GameController gameController;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

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
            rb.AddForceAtPosition(transform.up * carSpeed * gameController.PowerMultiplication, RearLeftTyre.transform.position);
            rb.AddForceAtPosition(transform.up * carSpeed * gameController.PowerMultiplication, RearRightTyre.transform.position);
        }

        if (Input.GetButton("Brakes"))
        {
            float brakeForce = 0;
            if(rb.velocity.magnitude <= 0)
            {
                brakeForce = 0.1F;
                rb.AddForceAtPosition(-transform.up * brakeForce, FrontLeftTyre.transform.position);
                rb.AddForceAtPosition(-transform.up * brakeForce, FrontRightTyre.transform.position);
            }
            else
            {
                brakeForce = brakingForce;
                rb.AddForceAtPosition(-transform.up * brakeForce * gameController.BrakesMultiplication, FrontLeftTyre.transform.position);
                rb.AddForceAtPosition(-transform.up * brakeForce * gameController.BrakesMultiplication, FrontRightTyre.transform.position);
            }
            
        }

        float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 10);

        rb.angularVelocity = Input.GetAxis("Horizontal") * tf * gameController.HandlingMultiplication;

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
