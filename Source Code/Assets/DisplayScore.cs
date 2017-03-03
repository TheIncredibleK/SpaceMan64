using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplayScore : MonoBehaviour {

    public string time;
    public string track;
    public string[] persString = new string[3];
    public Text text;

    // Use this for initialization
    void Start () {
        text = GameObject.Find("PlayerScore").GetComponent<Text>();
        persString = Scores.LoadTemp().Split(',');
        time = persString[0];
        track = persString[1];
        text.text = time;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
