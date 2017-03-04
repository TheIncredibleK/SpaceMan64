using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raceController : MonoBehaviour {

    public GameObject persistantObject;
    public Text totalTime;
    public Text timeRemaining;
    public Text countdown;

    public GameObject easyTrack;
    public GameObject mediumTrack;
    public GameObject hardTrack;

    public GameObject playerMovement;
    public GameObject waypointsController;
    public GameObject playerArrow;
    private float curDown = 3;
    private bool difficultyChosen = false;
    private string track;
    private bool trackBuilt;

	// Use this for initialization
	void Start () {
        curDown = 3;
    }
	
	// Update is called once per frame
	void Update () {
		if(difficultyChosen)
        {

            curDown -= Time.deltaTime;
            if(curDown >= 1)
            {
                countdown.text = "" + curDown.ToString("F0");
            }
            else
            {
                countdown.text = "";
                playerMovement.GetComponent<FlightController>().raceStart = true;
                waypointsController.GetComponent<waypointsController>().raceStarted = true;
            }
            
            if(!trackBuilt)
            {
				Debug.Log ("Building");
				Debug.Log (track);
                if(track.Equals("easy"))
                {
                    waypointsController = Instantiate(easyTrack, transform.position, transform.rotation);
                    waypointsController.GetComponent<waypointsController>().setVars(persistantObject, totalTime, timeRemaining);
                    playerArrow.GetComponent<guideArrow>().waypointsController = waypointsController;
                }
                if (track.Equals("medium"))
                {
					Debug.Log ("Building 2");
                    waypointsController = Instantiate(mediumTrack, transform.position, transform.rotation);
                    waypointsController.GetComponent<waypointsController>().setVars(persistantObject, totalTime, timeRemaining);
                    playerArrow.GetComponent<guideArrow>().waypointsController = waypointsController;
                }
                if (track.Equals("hard"))
                {
                    waypointsController = Instantiate(hardTrack, transform.position, transform.rotation);
                    waypointsController.GetComponent<waypointsController>().setVars(persistantObject, totalTime, timeRemaining);
                    playerArrow.GetComponent<guideArrow>().waypointsController = waypointsController;
                }
                trackBuilt = true;

				GetComponent<SpawnEnemy> ().SpawnEnemies ();
            }

        }
	}

    public void setDifficulty(string _track)
    {
        track = _track;
        difficultyChosen = true;
    }
}
