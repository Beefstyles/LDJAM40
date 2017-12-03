using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCar : MonoBehaviour {

    public Dictionary<float, Vector3> PositionRecorder;
    public Dictionary<float, Quaternion> RotationRecorder;

    float splitPoint = 0;

    public bool isRecording;
    public bool isPlayerCar;

	void Start ()
    {
		
	}
	
	void Update () {
        if (isRecording)
        {
            StartCoroutine("RecordPositionAndRotation");
        }
	}

    IEnumerator RecordPositionAndRotation()
    {
        splitPoint += 0.01F;
        yield return new WaitForSeconds(0.01F);

        PositionRecorder.Add(splitPoint, transform.position);
        RotationRecorder.Add(splitPoint, transform.rotation);
    }

    IEnumerator ReplayPositionAndRotation()
    {
        transform.position = PositionRecorder[splitPoint];
        transform.rotation = RotationRecorder[splitPoint];
        splitPoint += 0.01F;
        yield return new WaitForSeconds(0.01F);
    }
}
