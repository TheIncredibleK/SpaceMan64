using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Leap;
using Leap.Unity;

public class FlightController : MonoBehaviour
{
	Controller flyController;
	GestureRecogniser gestureRecogniser;
	public GameObject vehicle;
	public UnityEngine.UI.Image speedometer;
	float rotateAngleX;
	float rotateAngleZ;
	float rateOfChange = 0.00058f;
	float topRot = 1.0f;
	float currentMaxSpeed = 20.0f;
	float topSpeed = 20.0f;
	float nitrosSpeed;
	public float speed = 0.0f;
	float acceleration = 0.07f;
	float handling = 30.0f;
	float damper = .99f;
	Vector3 velocity = new Vector3(0.0f,0.0f,0.0f);
    public bool raceStart = false;

	// Use this for initialization
	void Start()
	{
		//Initalise flight controller
		flyController = new Controller();
		nitrosSpeed = topSpeed * 4.0f;
		gestureRecogniser = GetComponent<GestureRecogniser>(); 
		rotateAngleX = 0.0f;
		rotateAngleZ = 0.0f;


	}

    void Update()
    {
        if(raceStart)
        {
            flight();
        }
        
    }

	void flight()
	{
		System.Collections.Generic.List<Leap.Hand> hands = gestureRecogniser.getFrameHands();
		if (hands.Count == 2) {
			string current_gesture = gestureRecogniser.Recognise(hands[1]);
			string for_ui = gestureRecogniser.Recognise(hands[0]);
			string slow_down = gestureRecogniser.Recognise (hands [1]);
			Leap.Hand r_hand = hands [1];

			if (for_ui == "FIST") {
				topSpeed = nitrosSpeed;
				acceleration = .6f;
			} else if (for_ui == "UI") {
				damper = .6f;
				acceleration = .07f;
			}else{
				topSpeed = currentMaxSpeed;
				damper = .99f;
			}
			if (r_hand != null) {
				float RollAngle = r_hand.PalmNormal.Roll;
				float PitchAngle = r_hand.Direction.Pitch;
				Tilt (RollAngle);
				Rise (PitchAngle);
			}
			if (speed <= topSpeed) {
				speed += acceleration;
				acceleration += .008f;
			}
				
		}

		vehicle.transform.position += velocity;
		speed *= damper;
		velocity = (velocity.normalized * 2.0f + (vehicle.transform.forward)).normalized * speed * Time.deltaTime;


		speedometer.fillAmount = speed / topSpeed;

	}

	bool Tilt(float Roll)
	{

		if (Roll > 0.0f) {
			if (Roll > 1.0f && Roll < 2.0f) {
				Quaternion targetRotation = Quaternion.AngleAxis((1.0f * Mathf.Sign (Roll)), Vector3.up);
				vehicle.transform.rotation = Quaternion.Slerp(vehicle.transform.rotation , vehicle.transform.rotation *= targetRotation, handling * Time.deltaTime);
				return true;
			}
		} else {
			if(Roll > -2.4f && Roll < -1.5f){
				Quaternion targetRotation = Quaternion.AngleAxis((1.0f * Mathf.Sign (Roll)), Vector3.up);
				vehicle.transform.rotation = Quaternion.Slerp(vehicle.transform.rotation , vehicle.transform.rotation *= targetRotation, handling * Time.deltaTime);
				return true;
			}

		}

		return false;
	}
	void Rise(float Pitch)
	{
		float direction = 1.0f;
		if (Pitch > 1.6f) {
			direction *= -1;
			Quaternion targetQuat = Quaternion.AngleAxis (direction, Vector3.left);
			vehicle.transform.rotation = Quaternion.Slerp(vehicle.transform.rotation, vehicle.transform.rotation *= targetQuat, handling * Time.deltaTime);
		} else if (Pitch < 0.5f) {
			Quaternion targetQuat = Quaternion.AngleAxis (direction, Vector3.left);
			vehicle.transform.rotation = Quaternion.Slerp(vehicle.transform.rotation, vehicle.transform.rotation *= targetQuat, handling * Time.deltaTime);
		}

	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Asteroid") {
			Debug.Log ("Colliding");
			other.gameObject.GetComponent<Destruction> ().DestroySelf ();
			speed = speed / 2;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "enemyBullet") {
			healthTracker ht = GetComponentInParent<healthTracker> ();
			ht.damagePlayer (ht.maxHealth / 10);

			other.gameObject.GetComponent<enemyBullet> ().playHitSound ();
		}
	}


}
