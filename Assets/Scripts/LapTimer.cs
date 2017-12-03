using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimer : MonoBehaviour {

    public float TimerValue;
    LapController lapController;
    public Text TimerMinutes, TimerSeconds;


	void Start ()
    {
        ResetTimer();
        lapController = FindObjectOfType<LapController>();
    }
	
	void Update ()
    {
        if (lapController.LapStarted)
        {
            TimerValue += Time.deltaTime;
        }
	}

    void ResetTimer()
    {
        TimerValue = 0F;
    }
}
