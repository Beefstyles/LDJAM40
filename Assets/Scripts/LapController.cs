using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapController : MonoBehaviour {

    public bool LapStarted = false;
    public string BestLap;
    public string CurrentSplit;

    public Text BestLapText, CurrentSplitText;

    void Start ()
    {
		
	}

	void Update ()
    {
		
	}

    public void UpdateBestLapAndSplit()
    {
        BestLapText.text = BestLap;
        CurrentSplitText.text = CurrentSplit;
    }
}
