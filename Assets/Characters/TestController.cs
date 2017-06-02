using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

	AnimScript player;
	Transform child;

	// Use this for initialization
	void Start () {
		player = transform.Find ("Aj").gameObject.GetComponent<AnimScript> ();
		child = player.gameObject.transform;
	}

	void Update() {
		Vector3 temp = child.position;
		transform.position = temp;
		child.position = temp;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground") {
			player.jumping = 0;
		} else if (collision.gameObject.tag == "Ocean") {
			GameObject.Find ("HUD").GetComponent<GameOverManager> ().GameOver ();
		} else if (collision.gameObject.tag == "Target") {
			GameObject.Find ("HUD").GetComponent<GameOverManager> ().GamePass ();
		}
	}
}
