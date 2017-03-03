﻿using System.Collections;
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
    public bool winner;
    public bool scoreSubmitted;

    // Use this for initialization
    void Start () {
        //persistantObject = GameObject.Find("persistantObject");
        //time = persistantObject.GetComponent<persistantData>().getTime();
        //track = persistantObject.GetComponent<persistantData>().getTrack();
        //winner = persistantObject.GetComponent<persistantData>().getWinner();
        time = "2:12";
        track = "easy";

        text = GameObject.Find("EnterName").GetComponent<Text>();
        editText = "Enter Your Name:\n\n\n\n\n\n_ _ _ _ _ _ _ _ _ _";
        cursor = 21;
    }
	
	// Update is called once per frame
	void Update () {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (name.Length < 10 /**&& winner**/)
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
            }
        }
    }
}