using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	public float speed = 800.0f;
	public float speedMobile = 1200.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	#if UNITY_WEBPLAYER || UNITY_STANDALONE_WIN || UNITY_EDITOR
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody> ().AddForce (movement * speed * Time.deltaTime);
	#endif

	#if UNITY_IPHONE || UNITY_ANDROID
		float moveHorizontalMobile = Input.acceleration.x;
		float moveVerticalMobile = Input.acceleration.y;
		Vector3 movementMobile = new Vector3 (moveHorizontalMobile, 0.0f, moveVerticalMobile);
		GetComponent<Rigidbody> ().AddForce (movementMobile * speedMobile * Time.deltaTime);
	#endif
	}
}
