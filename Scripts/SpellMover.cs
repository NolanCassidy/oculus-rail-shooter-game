using UnityEngine;
using System.Collections;

public class SpellMover : MonoBehaviour {

	public float speed = 1.0f;

	// Update is called once per frame


	void Start () {
		//GameObject Player = GameObject.FindGameObjectWithTag ("Crosshair");
		//this.transform.rotation = Player.transform.rotation;
		//this.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
	}


	void Update () {
		transform.position += (-transform.forward * Time.deltaTime * speed);
		Debug.DrawLine (this.transform.position, this.transform.position + this.transform.forward, Color.red);
		Debug.DrawLine (this.transform.position, this.transform.position + this.transform.up, Color.green);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Target") {
			other.gameObject.SendMessage ("GnomeHit");
			Destroy (this.gameObject);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Boundary") {
			Destroy (this.gameObject);
		}
	}

}
