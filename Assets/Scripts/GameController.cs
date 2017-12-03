using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public float PowerMultiplication, BrakesMultiplication, HandlingMultiplication;

    public GameObject PlayerCar;
    public Transform PlayerSpawnLocation;
    private GameObject playerClone;

    CarController cc;
    LapTimer lapTimer;

    int numberOfGatesTrigged = 0;
    int numberOfGates = 0;
    public bool CanFinishLap = false;

    TimingGate[] timingGates;

    public void StartLap()
    {
        numberOfGates = 0;
        lapTimer.ResetTimer();
        cc = FindObjectOfType<CarController>();
        if(cc != null)
        {
            Destroy(cc.gameObject);
        }
        playerClone = Instantiate(PlayerCar, PlayerSpawnLocation.position, PlayerSpawnLocation.rotation) as GameObject;

        timingGates = FindObjectsOfType<TimingGate>();
        ResetAllGates();
    }



    void Start()
    {
        lapTimer = FindObjectOfType<LapTimer>();
        StartLap();
    }

    public void CheckIfAllGatesHit()
    {
        timingGates = FindObjectsOfType<TimingGate>();
        foreach (var gate in timingGates)
        {
            if (gate.TimingGateTriggered)
            {
                numberOfGatesTrigged++;
            }
        }

        if(numberOfGatesTrigged >= numberOfGates)
        {
            CanFinishLap = true;
        }
    }

    public void ResetAllGates()
    {
        numberOfGates = 0;
        timingGates = FindObjectsOfType<TimingGate>();
        foreach (var gate in timingGates)
        {
            numberOfGates++;
            gate.ResetGate();
        }
    }
}
