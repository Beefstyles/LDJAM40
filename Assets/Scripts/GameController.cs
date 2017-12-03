using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public float PowerMultiplication, BrakesMultiplication, HandlingMultiplication;

    public GameObject PlayerCar;
    public Transform PlayerSpawnLocation;
    private GameObject playerClone;
    LapTimer lapTimer;

    int numberOfGatesTrigged = 0;
    int numberOfGates = 0;
    public bool CanFinishLap = false;

    TimingGate[] timingGates;

    public void StartLap()
    {
        numberOfGates = 0;
        lapTimer.ResetTimer();
        if(playerClone != null)
        {
            Destroy(playerClone);
        }
        playerClone = Instantiate(PlayerCar, PlayerSpawnLocation.position, Quaternion.identity) as GameObject;

        timingGates = FindObjectsOfType<TimingGate>();
        foreach (var gate in timingGates)
        {
            numberOfGates++;
            gate.TimingGateTriggered = false;
        }
    }

    void Start()
    {
        
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

        }
    }
}
