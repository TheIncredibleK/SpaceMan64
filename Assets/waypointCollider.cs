using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointCollider : MonoBehaviour {

    public bool collided = false;
    public GameObject waypointController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 8)
        {
            if(waypointController.GetComponent<waypointsController>().nextWapoint == gameObject)
            {
                collided = true;
            }
            
            //Debug.Log("Collided");
            
        }
        
    }
}
