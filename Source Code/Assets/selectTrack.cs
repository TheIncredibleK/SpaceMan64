using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectTrack : MonoBehaviour {

    public raceController raceController;
    public string trackType;

	// Use this for initialization
	void Start () {
		Debug.Log ("TT: " + trackType);
		raceController = GameObject.FindGameObjectWithTag("Rig").GetComponent<raceController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
    {

		if (col.gameObject.tag == "Hand") {

			Debug.Log ("Hello");
			raceController.setDifficulty (trackType);
			Destroy (GameObject.FindGameObjectWithTag ("Menu"));
		}
    }
}
