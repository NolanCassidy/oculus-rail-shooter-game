using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour {

	public float direction;
	public float speed = 20.0f;
	private bool doorsOpening;
	private bool doorsClosing;

	// Use this for initialization
	void Start () {
		doorsOpening = false;
		doorsClosing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (doorsOpening) {
			if (direction == 1) {
				if (transform.localRotation.eulerAngles.y < 90) {
					transform.RotateAround (transform.position, Vector3.up, speed * direction * Time.deltaTime);
				} else {
					doorsOpening = false;
					doorsClosing = true;

				}
			} else {
				if (transform.localRotation.eulerAngles.y > 270 || transform.localRotation.eulerAngles.y == 0) {
					transform.RotateAround (transform.position, Vector3.up, speed * direction * Time.deltaTime);
				} else {
					doorsOpening = false;
					doorsClosing = true;
				}
			}
		}
	
	if (doorsClosing) {
			if (direction == 1) {
				if (transform.localRotation.eulerAngles.y > 0 && transform.localRotation.eulerAngles.y < 359) {
					transform.RotateAround (transform.position, Vector3.up, speed * -direction * Time.deltaTime);
				} else {
					doorsClosing = false;
				}
			} else {
				if (transform.localRotation.eulerAngles.y > 269 && transform.localRotation.eulerAngles.y < 359) {
					transform.RotateAround (transform.position, Vector3.up, speed * -direction * Time.deltaTime);
				} else {
					doorsClosing = false;
				}
			}
		}
	
	
	}

	void OpenDoors() {
		transform.RotateAround (transform.position, Vector3.up, speed * direction * Time.deltaTime);
		doorsOpening = true;

	}
}
