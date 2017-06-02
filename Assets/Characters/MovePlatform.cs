using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {

	[SerializeField] public Transform platform;
	[SerializeField] public Transform start;
	[SerializeField] public Transform end;

	public Vector3 newPosition;
	private bool state;
	public float smooth;
	public float resetTime;
	private AudioSource audio;


	// Use this for initialization
	void Start () {
		state = false;
		audio = gameObject.GetComponent<AudioSource>();
		Reverse();
	}

	// Update is called once per frame
	void Update () {
		platform.position = Vector3.Lerp(platform.position, newPosition, smooth * Time.deltaTime);
		float diff1 = Mathf.Abs (platform.position.y - newPosition.y);
		float diff2 = Mathf.Abs (start.position.y - end.position.y);
		if (diff1 > diff2 * 0.01) {
			if (!audio.isPlaying) audio.PlayOneShot (audio.clip);
		} else {
			audio.Stop ();
		}
	}

	void Reverse()
	{
		newPosition = (state) ? end.position : start.position;
		state = !state;

		Invoke("Reverse", resetTime);
	}
}
