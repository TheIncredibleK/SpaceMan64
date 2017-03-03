using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioClip))]
public class SoundController : MonoBehaviour {

	public AudioClip rumble;
	AudioSource rumbler;
	bool rumbleOn = false;
	bool currentlyFlying = false;
	// Use this for initialization
	void Start () {
		rumbler = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentlyFlying = (this.GetComponent<FlightController> ().speed > 0.5f);
		if (!rumbleOn) {
			if (currentlyFlying) {
				rumbler.clip = rumble;
				rumbler.loop = true;
				rumbler.Play ();
				rumbleOn = true;

			}  else {
				rumbleOn = false;
				rumbler.Stop ();
			}

		}

		
	}
		
}
