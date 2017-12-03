using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public float PowerMultiplication, BrakesMultiplication, HandlingMultiplication;

    public GameObject PlayerCar;
    public Transform PlayerSpawnLocation;
    private GameObject playerClone;
    LapTimer lapTimer;

    public void StartLap()
    {
        lapTimer.ResetTimer();
        if(playerClone != null)
        {
            Destroy(playerClone);
        }
        playerClone = Instantiate(PlayerCar, PlayerSpawnLocation.position, Quaternion.identity) as GameObject;
    }
}
