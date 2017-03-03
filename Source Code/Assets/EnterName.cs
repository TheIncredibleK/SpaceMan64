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
    public String name;
    public String time;
    public String track;
    public string[] persString = new string[3];
    public Boolean winner;
    public bool scoreSubmitted;

    // Use this for initialization
    void Start () {
        persString = Scores.LoadTemp().Split(',');
        time = persString[0];
        track = persString[1];
        winner = Convert.ToBoolean(persString[2]);

        text = GameObject.Find("EnterName").GetComponent<Text>();
        editText = "Enter Your Name:\n\n\n\n\n\n_ _ _ _ _ _ _ _ _ _";
        cursor = 21;
    }
	
	// Update is called once per frame
	void Update () {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (name.Length < 10 && winner /**&& Scores.CheckScore(track,time)**/)
            {
                if (Input.GetKeyDown(key) && !(Input.GetKeyDown("return")))
                {
                    Debug.Log(key);
                    editText = editText.Insert(cursor, key.ToString());
                    name += key.ToString();
                    cursor++;
                    editText = editText.Insert(cursor, " ");
                    cursor++;
                    text.text = editText;
                    Debug.Log(editText.ToString());
                }
            }
            if ((Input.GetKeyDown("return"))){
                Debug.Log("Trying to save");
                scoreSubmitted = true;
                Scores.SubmitScore(track, time, name);
            }
        }
    }
}
