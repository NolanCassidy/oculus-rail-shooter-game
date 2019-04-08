using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private int count;
	private Text scoreText;
	private GameObject startDoor1;
	private GameObject startDoor2;

	// Use this for initialization
	void Start () {

		startDoor1 = GameObject.Find ("Start Door (1)");
		startDoor2 = GameObject.Find ("Start Door (2)");
		scoreText = GameObject.Find ("Score Text").GetComponent<Text>();
		count = 0;
	}

	void IncreaseScore() { 
		count += 100;
		scoreText.text = "$" + count.ToString ();
		if (count >= 3000) {
			scoreText.rectTransform.localPosition = Vector3.zero;
			scoreText.text = "ALL JAMIES RICH";
		}
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "StartDoorTrigger") {
			startDoor1.SendMessage ("OpenDoors");
			startDoor2.SendMessage ("OpenDoors");
	
	}
}
}
