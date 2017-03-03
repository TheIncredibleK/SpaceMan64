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
    public TrackScores scores;
    public bool submittedNewScore;


    // Use this for initialization
    void Start()
    {
        //persistantObject = GameObject.Find("persistantObject");
        //submittedNewScore = GameObject.Find("EnterName").GetComponent<EnterName>().scoreSubmitted;
        //time = persistantObject.GetComponent<persistantData>().getTime();
        //track = persistantObject.GetComponent<persistantData>().getTrack();
        //winner = persistantObject.GetComponent<persistantData>().getWinner();
        text = GameObject.Find("LeaderboardBody").GetComponent<Text>();
        //scores = Scores.GetScores(track);
        //names = scores.names;
    }
	
	// Update is called once per frame
	void Update () {
        /**if (Scores.CheckScore(track, time)/**&&submittedNewScore)
        {
            scores = Scores.GetScores(track);
        }**/
        for (int i = 0; i<names.Length; i++)
        {
            if (i == 0)
            {
                text.text = i+1 + ". " + names[i] + "  " + times[i] + "\n";
            }
            else
            {
                text.text += i + 1 + ". " + names[i] + "  " + times[i] + "\n";
            }
        }
	}
}
