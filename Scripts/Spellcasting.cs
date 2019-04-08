using UnityEngine;
using System.Collections;

public class Spellcasting : MonoBehaviour {

	public Transform spellEffect;
	public float timeBetweenShots = 10.0f;
	private float shootTime;
	private Vector3 crosshairPos;
	private GameObject crosshair;
	private Vector3 mousePos;
	private Transform anchor;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		shootTime = Time.time;
		crosshair = GameObject.Find ("Crosshair");
		anchor = GameObject.Find ("CenterEyeAnchor").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = GameObject.FindGameObjectWithTag ("MainCamera").transform.position;
		mousePos = Input.mousePosition;
		RaycastHit hit;
		if (Physics.Raycast (anchor.position, Camera.main.ScreenToWorldPoint (mousePos), out hit, Mathf.Infinity)) {
			mousePos.z = hit.distance;
		}
		crosshairPos = crosshair.transform.position;
		Vector3 dP = crosshairPos - anchor.position;
		Quaternion shotRot = Quaternion.LookRotation (dP, Vector3.forward);
		if (Time.timeScale > 0) {
			if (Input.GetMouseButton (0) && Time.time > shootTime) {
				shootTime = Time.time + timeBetweenShots;
				Instantiate(spellEffect, crosshairPos, this.transform.rotation);//shotRot);
			}
		}
	}

}
