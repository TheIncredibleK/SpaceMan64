using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	   
	}

    void OnTriggerEnter(Collider col){
        Debug.Log("Hello");
        SceneManager.LoadScene("Main");
    }
    

}
