using UnityEngine;
using System.Collections;

public class GnomeController : MonoBehaviour {

	private GameObject player;
	private float dist;
	private bool rising = false;
	private bool falling = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Spline Follower");
	}
	
	// Update is called once per frame
	void Update () {
		dist = Vector3.Distance (transform.position, player.transform.position);
		if (dist <= 50.0f && !rising) {
			rising = true;
		}
		if (rising && transform.position.y <= -12.06) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.2f, transform.position.z);
		}
		if (falling && (transform.rotation.eulerAngles.x > 270 || transform.rotation.eulerAngles.x == 0)) {
			transform.Rotate (new Vector3(1, 0, 0) * Time.deltaTime * -90);
	}
}
	void GnomeHit () {
		if (!falling) {
			falling = true;
			player.SendMessage("IncreaseScore");
		}
	}
}