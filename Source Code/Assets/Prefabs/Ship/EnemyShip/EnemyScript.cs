using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public float chargeTime = 5.0f;
	public float mass = 10.0f;
	public float moveSpeed = 7.0f;
	private float time = 0;
	public float contactDist = 100.0f;
	private Rigidbody rb;
	private Vector3 velocity = Vector3.zero;
	private Vector3 acceleration = Vector3.zero;
	private Vector3 target;
	public Vector3 gatePos;
	public float wanderRad = 50.0f;

	public GameObject playerParent;
	public GameObject player;
	public GameObject bulletPrefab;

	private bool focusedIn = false;


	// Use this for initialization
	void Start () {
		playerParent = GameObject.Find ("PillShip");
		foreach (Transform child in playerParent.transform) {
			if (child.tag == "Player")
				player = child.gameObject;
		}

		rb = this.GetComponent<Rigidbody> ();
		target =  gatePos + Random.insideUnitSphere * wanderRad;
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (player.transform.position, transform.position) < contactDist) {
			focusedIn = true;
	
			Turn(player.transform.position);

			time += Time.deltaTime;

			//if infront then shoot
			float angle = 10;
			if  (Vector3.Angle( transform.position - player.transform.position,-transform.forward) < angle) {
				Debug.Log ("shooting..");
				if (time > (int)Random.Range(3,6)) {
					GameObject bullet = GameObject.Instantiate<GameObject> (bulletPrefab);
					bullet.transform.position = transform.position + 3 * transform.forward;
					bullet.transform.rotation = transform.rotation;

					time = 0;
				}
			}

		} 
		else {
			if(Vector3.Distance(target, transform.position) <= 5.0f){
				target = gatePos;
			int mindist = 10;
				int randIndex = Random.Range (0, 2);
			int randIndz = Random.Range (0, 2);
			int randIndy = Random.Range (0, 2);

			float[] x =	new float[] { Random.Range (-wanderRad, -mindist), Random.Range (mindist, wanderRad) };
			float[] y =	new float[] { Random.Range (-wanderRad, -mindist), Random.Range (mindist, wanderRad) };
			float[] z =	new float[] { Random.Range (-wanderRad, -mindist), Random.Range (mindist, wanderRad) };
				target.x += x[randIndex];
			target.z += z[randIndz];
			target.y += y[randIndy];
			}


			Turn (target);
			transform.position += transform.forward * Time.deltaTime * moveSpeed;
		}
	}

	void Turn(Vector3 target){
		Quaternion targetRot = Quaternion.LookRotation (target - transform.position);
		float turnforce = Mathf.Min ((moveSpeed/5) * Time.deltaTime, 1);
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRot, turnforce);
	}

}
