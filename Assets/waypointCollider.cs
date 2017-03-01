using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointCollider : MonoBehaviour {

    public bool collided = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter()
    {
        Debug.Log("Collided");
        collided = true;
    }
}
