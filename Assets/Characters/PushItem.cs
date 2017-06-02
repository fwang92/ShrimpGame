using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushItem : MonoBehaviour {

	public float pushStrength;
	private bool collision;
	private AudioSource audio;
	private float played;

	void Start()
	{
		audio = gameObject.GetComponent<AudioSource>();
	}

	void Update()
	{

	}

	public void OnCollisionEnter(Collision col)
	{
		if (Time.time - played >= 1f) {
			audio.PlayOneShot (audio.clip);
			played = Time.time;
		}
	}

	/*
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		collision = true;
		Rigidbody body = hit.collider.attachedRigidbody;

		if (body == null || body.isKinematic)
			return;

		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

		body.velocity = pushDir * pushStrength;
	}
	*/
}
