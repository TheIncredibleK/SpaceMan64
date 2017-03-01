using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointsController : MonoBehaviour {


    public GameObject[] waypoints;
    public GameObject nextWapoint;
    public float countDown;
    public float curDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < waypoints.Length; i++)
        {
            if (!waypoints[i].GetComponent<waypointCollider>().collided)
            {
                if(nextWapoint != waypoints[i])
                {
                    nextWapoint = waypoints[i];
                    curDown = countDown;
                }
                break;
            }
        }
        curDown -= Time.deltaTime;
	}
}
