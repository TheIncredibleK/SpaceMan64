using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HighScore : MonoBehaviour {

    public Text text;
    public string[] times = new string[]
    {
        "__:__", "__:__", "__:__", "__:__", "__:__"
    };
    public string[] names = new string[]
    {
            "_ _ _ _", "_ _ _ _", "_ _ _ _", "_ _ _ _", "_ _ _ _"
    };
    public GameObject persistantObject;
    public string track;
    public string time;
    public bool winner;
    public string[] persString;
    public TrackScores scores;
    public bool submittedNewScore;
    public bool checkedScore;


    // Use this for initialization
    void Start()
    {
        checkedScore = false;
        text = GameObject.Find("LeaderboardBody").GetComponent<Text>();
        submittedNewScore = GameObject.Find("EnterName").GetComponent<EnterName>().scoreSubmitted;
        persString = Scores.LoadTemp().Split(',');
        track = persString[1];
        scores = Scores.GetScores(track);
        names = scores.names;
        times = scores.times;
        for (int i = 0; i < names.Length; i++)
        {
            if (i == 0)
            {
                text.text = i + 1 + ". " + names[i] + "  " + times[i] + "\n";
            }
            else
            {
                text.text += i + 1 + ". " + names[i] + "  " + times[i] + "\n";
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    void checkSubmitted()
    {

    }

}
