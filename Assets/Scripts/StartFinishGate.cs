using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFinishGate : MonoBehaviour {


    LapController lapController;
    GhostCar ghostCar;

	void Start ()
    {
        lapController = FindObjectOfType<LapController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.tag == "PlayerCar")
        {
            if (!lapController.LapStarted)
            {
                lapController.LapStarted = true;
                ghostCar = coll.GetComponent<GhostCar>();
                ghostCar.isRecording = true;
                Debug.Log("Exited Through Gate");
            }
            else
            {
                lapController.LapFinished();
            }
            
            
        }
    }


}
