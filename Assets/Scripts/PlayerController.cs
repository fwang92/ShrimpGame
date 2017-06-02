using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Vector3 jump;
	public float jumpForce ;

	public bool isGrounded;
	Rigidbody rb;

	MicrophoneListener voice;

	void Start(){
		rb = GetComponent<Rigidbody>();
		jump = new Vector3(0.0f, 2.0f, 0.0f);
		voice = GameObject.Find ("VoiceInput").GetComponent<MicrophoneListener>();

	}

	void Update()
	{	
		Debug.Log (voice.soundConvertedData);
		var z = 0.0f;
		if (voice.soundConvertedData >= 3.0f && voice.soundConvertedData < 12.0f) {
			z = Time.deltaTime * 3.5f;

		} else {
			z = 0.0f;
		}
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

		if(voice.soundConvertedData >= 12.0f && isGrounded){
			jumpForce = voice.soundConvertedData >= 42.0f ? 7.0f : (voice.soundConvertedData / 6.0f);
			rb.AddForce(jump * jumpForce, ForceMode.Impulse);// jumpForce <= 7.0
			isGrounded = false;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		isGrounded = true;
	}
}
