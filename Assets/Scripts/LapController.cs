using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapController : MonoBehaviour {

    public bool LapStarted = false;
    public string BestLap;
    public string CurrentSplit;
    private float bestLapFloat = 0;
    private float splitFloat = 0;
    LapTimer lapTimer;
    private int elapsedMinutes;
    private int elapsedSeconds;
    private float fraction;

    public Transform playerSpawnPoint;

    public Text BestLapText, CurrentSplitText;

    GameController gc;

    void Start ()
    {
        lapTimer = FindObjectOfType<LapTimer>();
        gc = FindObjectOfType<GameController>();
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

        splitFloat = Mathf.Abs(bestLapFloat - lapTimer.TimerValue);
        elapsedMinutes = (int)splitFloat / 60;
        elapsedSeconds = (int)splitFloat % 60;
        fraction = splitFloat * 1000;
        fraction = (fraction % 1000);
        if (lapTimer.TimerValue <= bestLapFloat)
        {
            CurrentSplit = "-" + string.Format("{0:0}:{1:00}.{2:000}", elapsedMinutes, elapsedSeconds, fraction);
        }
        else
        {
            CurrentSplit = "+" + string.Format("{0:0}:{1:00}.{2:000}", elapsedMinutes, elapsedSeconds, fraction);
        }
        
        UpdateBestLapAndSplit();
        lapTimer.ResetTimer();
        gc.ResetAllGates();
    }
}
