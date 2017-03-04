using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour {
	Color current_color;
	Color last_color;
	float time_elapsed;
	// Use this for initialization
	void Start () {
		current_color = Color.blue;
		last_color = Color.blue;;
	}
	
	// Update is called once per frame
	void Update () {
		
		current_color = this.GetComponent<Renderer> ().material.color;

		if(current_color != last_color) {
			time_elapsed = 0;
			current_color = new Color (Random.Range (0, 255), Random.Range (0, 255), Random.Range (0, 255), 1.0f);
		}
		time_elapsed += Time.deltaTime;
		this.GetComponent<Renderer> ().material.color = Color.Lerp (last_color, current_color, time_elapsed);

	}
}
