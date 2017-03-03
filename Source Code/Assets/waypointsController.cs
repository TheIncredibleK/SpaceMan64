using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class waypointsController : MonoBehaviour {


    public GameObject[] waypoints;
    public GameObject nextWapoint;
    public GameObject persistantObject;
    public float countDown;
    public float curDown;
    public float timeBonus;
    public Text timeRemaining;
    public Text totalTime;
    private float curOverTime = 0;
    public string trackName;
    public bool raceStarted = false;
    public float minutes = 0;
    private string timeSave;

    // Use this for initialization
    void Start () {
        nextWapoint = waypoints[0];
        curDown = countDown;
        var main = nextWapoint.GetComponent<waypointCollider>().ps.main;
        main.startColor = new Color(0, 1, 0, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
        
		for(int i = 0; i < waypoints.Length; i++)
        {
            if (i == waypoints.Length-1 && waypoints[i].GetComponent<waypointCollider>().collided)
            {
                
                gameOver(true);
                SceneManager.LoadScene("Exit");
            }
            else if (waypoints[i].GetComponent<waypointCollider>().collided)
            {
                if(nextWapoint == waypoints[i])
                {
                    nextWapoint = waypoints[i+1];
                    var main = nextWapoint.GetComponent<waypointCollider>().ps.main;
                    main.startColor = new Color(0, 1, 0, 0.1f);
                    curDown += timeBonus;
                }
            }
        }
        if(raceStarted)
        {
            timeRemaining.text = "" + curDown.ToString("F2");
            if(minutes > 0)
            {
                if(minutes < 10 && curOverTime < 10)
                {
                    totalTime.text = "Total Time:0" + minutes.ToString("F0") + ".0" + (curOverTime).ToString("F0");
                }
                else if(minutes < 10)
                {
                    totalTime.text = "Total Time:0" + minutes.ToString("F0") + "." + (curOverTime).ToString("F0");
                }
                else if(curOverTime < 10)
                {
                    totalTime.text = "Total Time:" + minutes.ToString("F0") + ".0" + (curOverTime).ToString("F0");
                }
                else
                {
                    totalTime.text = "Total Time:" + minutes.ToString("F0") + "." + (curOverTime).ToString("F0");
                }
                
            }
            else
            {
                if(curOverTime < 10)
                {
                    totalTime.text = "Total Time:00.0" + (curOverTime).ToString("F0");
                }
                else
                {
                    totalTime.text = "Total Time:00." + (curOverTime).ToString("F0");
                }
            }
            curDown -= Time.deltaTime;
            curOverTime += Time.deltaTime;
        }
        if(curOverTime >= 60)
        {
            minutes += 1;
            curOverTime -= 60;
        }
        if(curDown <= 0.0f)
        {
            gameOver(false);
        }
	}

    public void setVars(GameObject _persistantObject, Text _totalTime, Text _timeRemaining)
    {
        persistantObject = _persistantObject;
        totalTime = _totalTime;
        timeRemaining = _timeRemaining;
    }

    public void gameOver(bool winner)
    {
        timeSave = minutes + ":" + curOverTime;
        Scores.SaveTemp(timeSave, trackName, winner);
        SceneManager.LoadScene("Exit");
    }
}
