using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimer : MonoBehaviour {

    public float TimerValue;
    LapController lapController;
    public Text TimerText;
    private int elapsedMinutes, elapsedSeconds;
    private float fraction;
    string timerText;


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
            int timerVal = (int)TimerValue;

            elapsedMinutes = timerVal / 60;
            elapsedSeconds = timerVal % 60;
            fraction = TimerValue * 1000;
            fraction = (fraction % 1000);
            timerText = string.Format("{0:0}:{1:00}.{2:000}", elapsedMinutes, elapsedSeconds, fraction);
            TimerText.text = timerText;
        }
	}

    public void ResetTimer()
    {
        TimerValue = 0F;
        TimerText.text = "";
    }

}
