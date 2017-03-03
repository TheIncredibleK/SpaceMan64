using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public float chargeTime = 5.0f;
	public GameObject player;
	public GameObject bulletPrefab;
	private float time = 0;
	public float moveSpeed = 5.0f;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("PillShip");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, transform.position) < 200.0f) {
			this.transform.LookAt (player.transform.position);

			time += Time.deltaTime;
			if (time >= chargeTime) {
				GameObject bullet = GameObject.Instantiate<GameObject> (bulletPrefab);
				bullet.transform.position = transform.position + 3 * transform.forward;
				bullet.transform.rotation = transform.rotation;

				time = 0;
			}
		}
	}


}
