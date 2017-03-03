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
    public bool deleting;

    // Use this for initialization
    void Start () {
        scoreSubmitted = false;
        persString = Scores.LoadTemp().Split(',');
        time = persString[0];
        track = persString[1];
        winner = Convert.ToBoolean(persString[2]);
        leaderboard = GameObject.Find("LeaderboardBody").GetComponent<Text>();
        text = GameObject.Find("EnterName").GetComponent<Text>();
        editText = "Enter Your Name:\n\n\n\n\n\n_ _ _ _ _ _ _ _ _ _";
        cursor = 21;
        deleting = false;
    }
	
	// Update is called once per frame
	void Update () {
        scoreSubmitted = false;
        deleting = false;
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (winner)
            {
                if (name.Length < 10 && Input.GetKeyDown(key) && !(Input.GetKeyDown("return"))&& char.IsLetter(key.ToString().ToCharArray()[0]) && (key.ToString().Length==1))
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
                if ((Input.GetKeyDown("return"))&&!scoreSubmitted && name.Length > 0)
                {
                    Debug.Log("Trying to save " +name);
                    scoreSubmitted = true;
                    submit(track, time, name);
                }
                if ((Input.GetKeyDown(KeyCode.Backspace)) && name.Length >0 &&!deleting)
                {
                    deleting = true;
                    Debug.Log("Deleting");
                    name = name.Remove(name.Length - 1);
                    Debug.Log(name);
                    cursor--;
                    cursor--;
                    editText = editText.Remove(cursor, 1);
                    text.text = editText;
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
