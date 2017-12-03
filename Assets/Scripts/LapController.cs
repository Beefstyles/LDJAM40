using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapController : MonoBehaviour {

    public bool LapStarted = false;
    public string BestLap;
    public string CurrentSplit;
    private float bestLapFloat = 0;
    LapTimer lapTimer;
    private int elapsedMinutes;
    private int elapsedSeconds;
    private float fraction;

    public Transform playerSpawnPoint;

    public Text BestLapText, CurrentSplitText;

    void Start ()
    {
        lapTimer = FindObjectOfType<LapTimer>();
    }

	void Update ()
    {
		
	}

    private void UpdateBestLapAndSplit()
    {
        BestLapText.text = BestLap;
        CurrentSplitText.text = CurrentSplit;
    }

    public void LapFinished()
    {
        if(lapTimer.TimerValue >= bestLapFloat)
        {
            bestLapFloat = lapTimer.TimerValue;

            elapsedMinutes = (int)bestLapFloat / 60;
            elapsedSeconds = (int)bestLapFloat % 60;
            fraction = bestLapFloat * 1000;
            fraction = (fraction % 1000);
            BestLap = string.Format("{0:0}:{1:00}.{2:000}", elapsedMinutes, elapsedSeconds, fraction);
        }
        UpdateBestLapAndSplit();
        lapTimer.ResetTimer();
    }
}
