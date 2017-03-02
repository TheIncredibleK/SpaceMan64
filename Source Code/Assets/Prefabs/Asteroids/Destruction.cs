using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {


	public GameObject destructionGib;


	public void DestroySelf() {
		if (destructionGib != null) {
			Instantiate (destructionGib, this.transform.position, Quaternion.identity);
		}
		Destroy (this.gameObject);
	}
}
