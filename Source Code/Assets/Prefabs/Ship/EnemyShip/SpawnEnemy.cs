using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
	
	private GameObject[] waypoints;
	public GameObject raceObject;
	private raceController racecontroller;
	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		if (raceObject == null) {
			raceObject = GameObject.Find ("raceController");
		}
		racecontroller = raceObject.GetComponent<raceController> ();
	}


	public void SpawnEnemies(){
		waypointsController way = (waypointsController)racecontroller.waypointsController.GetComponent<waypointsController>();
		List<Vector3> points = new List<Vector3> ();

		for (int i = 0; i < way.waypoints.Length; i++) {
			if (i % 4 == 0) {
				Vector3 point = way.waypoints [i].transform.position;

				GameObject enemy1 = GameObject.Instantiate<GameObject> (enemyPrefab);
				enemy1.transform.position = point + way.waypoints [i].transform.right * 10;
				enemy1.transform.rotation = way.waypoints [i].transform.rotation;

				GameObject enemy2 = GameObject.Instantiate<GameObject> (enemyPrefab);
				enemy2.transform.position = point  - way.waypoints [i].transform.right * 10;
				enemy2.transform.rotation = way.waypoints [i].transform.rotation;

			}
		}


	}
}
