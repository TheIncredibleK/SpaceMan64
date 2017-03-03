using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {


	public GameObject destructionGib;
	public AudioClip death;


	public void DestroySelf() {
		if (destructionGib != null) {
			Instantiate (destructionGib, this.transform.position, Quaternion.identity);
		}
		if (death != null) {
			AudioSource.PlayClipAtPoint(death, this.transform.position);

		}
		Destroy (this.gameObject);
	}
}
