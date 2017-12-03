using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingGate : MonoBehaviour {

    public bool TimingGateTriggered;
    GameController gc;

    void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "PlayerCar")
        {
            TimingGateTriggered = true;
            gc.CheckIfAllGatesHit();
        }
    }
}
