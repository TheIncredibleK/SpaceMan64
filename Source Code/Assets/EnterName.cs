using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnterName : MonoBehaviour {

    public String editText;
    public Text text;
    public int cursor;
    public GameObject persistantObject;
    public Text leaderboard;
    public String name;
    public String time;
    public String track;
    public string[] persString = new string[3];
    public Boolean winner;
    public bool scoreSubmitted;
    public string[] times;
    public string[] names;
    public TrackScores scores;

    // Use this for initialization
    void Start () {
        scoreSubmitted = false;
        //persString = Scores.LoadTemp().Split(',');
        time = "22:30";//persString[0];
        track = "easy";//persString[1];
        winner = true;//Convert.ToBoolean(persString[2]);
        leaderboard = GameObject.Find("LeaderboardBody").GetComponent<Text>();
        text = GameObject.Find("EnterName").GetComponent<Text>();
        editText = "Enter Your Name:\n\n\n\n\n\n_ _ _ _ _ _ _ _ _ _";
        cursor = 21;
    }
	
	// Update is called once per frame
	void Update () {
        scoreSubmitted = false;
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (name.Length < 10 && winner /**&& Scores.CheckScore(track,time)**/)
            {
                if (Input.GetKeyDown(key) && !(Input.GetKeyDown("return")))
                {
                    //Debug.Log(key);
                    editText = editText.Insert(cursor, key.ToString());
                    name += key.ToString();
                    cursor++;
                    editText = editText.Insert(cursor, " ");
                    cursor++;
                    text.text = editText;
                    //Debug.Log(editText.ToString());
                }
                if ((Input.GetKeyDown("return"))&&!scoreSubmitted)
                {
                    //Debug.Log("Trying to save");
                    scoreSubmitted = true;
                    submit(track, time, name);
                }
            }
        }
    }

    void submit(string track, string time, string name)
    {
        if (scoreSubmitted)
        {
            Debug.Log("Counting");
            Scores.SubmitScore(track, time, name);
            scores = Scores.GetScores(track);
            names = scores.names;
            times = scores.times;
            for (int i = 0; i < names.Length; i++)
            {
                if (i == 0)
                {
                    leaderboard.text = i + 1 + ". " + names[i] + "  " + times[i] + "\n";
                }
                else
                {
                    leaderboard.text += i + 1 + ". " + names[i] + "  " + times[i] + "\n";
                }
            }
            winner = false;
            text.text = "Enter Your Name:\n\n\n\n\n\n_ _ _ _ _ _ _ _ _ _";
        }
    }
}
