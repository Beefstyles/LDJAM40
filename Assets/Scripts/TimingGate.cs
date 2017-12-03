using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingGate : MonoBehaviour {

    public bool TimingGateTriggered;
    GameController gc;
    public Sprite NonTriggered, Triggered;
    private SpriteRenderer sr;

    void Start()
    {
        gc = FindObjectOfType<GameController>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void ResetGate()
    {
        TimingGateTriggered = false;
        sr.sprite = NonTriggered;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "PlayerCar")
        {
            TimingGateTriggered = true;
            sr.sprite = Triggered;
            gc.CheckIfAllGatesHit();
        }
    }
}
