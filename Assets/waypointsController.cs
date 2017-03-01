using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waypointsController : MonoBehaviour {


    public GameObject[] waypoints;
    public GameObject nextWapoint;
    public float countDown;
    public float curDown;
    public Text timeRemaining;
    public Text totalTime;
    private float curOverTime = 0;

	// Use this for initialization
	void Start () {
        nextWapoint = waypoints[0];
        curDown = countDown;
	}
	
	// Update is called once per frame
	void Update () {
        timeRemaining.text = "Time Remaining:"+curDown.ToString("F2");
        totalTime.text = "Total Time:" + (curOverTime + (countDown - curDown)).ToString("F2");
		for(int i = 0; i < waypoints.Length; i++)
        {
            if (i == waypoints.Length-1 && waypoints[i].GetComponent<waypointCollider>().collided)
            {
                Debug.Log("Winner");
            }
            else if (waypoints[i].GetComponent<waypointCollider>().collided)
            {
                if(nextWapoint == waypoints[i])
                {
                    nextWapoint = waypoints[i+1];
                    curOverTime += countDown - curDown;
                    curDown = countDown;
                }
            }
        }
        curDown -= Time.deltaTime;
        if(curDown <= 0.0f)
        {
            Debug.Log("Loser");
        }
	}
}
