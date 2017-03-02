using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guideArrow : MonoBehaviour {

    public GameObject waypointsController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(waypointsController.GetComponent<waypointsController>().nextWapoint.transform);
	}
}
