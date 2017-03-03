using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectTrack : MonoBehaviour {

    public raceController raceController;
    public string trackType;

	// Use this for initialization
	void Start () {
        trackType = gameObject.ToString().ToLower();
        raceController = GameObject.Find("raceController").GetComponent<raceController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Hello");
        raceController.setDifficulty(trackType);
        Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
    }
}
