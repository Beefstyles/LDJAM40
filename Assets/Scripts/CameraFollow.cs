using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

	void Update ()
    {
        if(target == null)
        {
            target = FindObjectOfType<CarController>().transform;
        }
        transform.position = new Vector3(target.position.x, target.position.y, -10F);
	}
}
