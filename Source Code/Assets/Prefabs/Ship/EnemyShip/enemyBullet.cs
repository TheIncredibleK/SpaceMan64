using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour {
	public float destroyTime = 5.0f;
	public float speed = 20.0f;

	// Use this for initialization
	void Start () {
		Invoke ("Destroy", destroyTime);
	}

	void Destroy(){
		Destroy (this.gameObject, destroyTime);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}
}
