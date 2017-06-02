using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {

    private Animator animator;
    private float speed;

	private CharacterController characterController;
	[SerializeField] public AudioClip[] footstepSounds;
	[SerializeField] public ParticleSystem footStepParticles;
	private AudioSource footStepAudio;
	private Transform chara;
	public CameraScript camera;

	private float lastFootLeft;
	private float currFootLeft;
	private float lastFootRight;
	private float currFootRight;
	private bool oldRagDoll;
	private float deathTime;

	Rigidbody rb;
	public int jumping;
	private Vector3 jump;
	public float forwardForce;
	private float jumpForce ;
	private float jumpTime;
	MicrophoneListener voice;

	// Use this for initialization
	void Start () {
		voice = GameObject.Find ("VoiceInput").GetComponent<MicrophoneListener>();//get voice data
		animator = GetComponent<Animator>();
        speed = 1;
		characterController = GetComponent<CharacterController>();
		footStepAudio = gameObject.GetComponent<AudioSource>();
		chara = transform;
		oldRagDoll = false;
		deathTime = 0f;
		rb = transform.parent.GetComponent<Rigidbody> ();
		jumping = 0;
		jumpTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("Forward", 1.0f);
//		if (voice.soundConvertedData >= 10.0f) {
//
////			forwardForce = voice.soundConvertedData / 10.0f;
//
//			animator.SetFloat ("Forward", 1.0f);
//		} else if (voice.soundConvertedData < 10.0f) {
//			animator.SetFloat ("Forward", 0.0f);
//		}
		//animator.SetFloat ("Forward", Input.GetAxis ("Vertical"));
		//这里是前进。
//
		float h1 = Input.GetAxis ("Horizontal");
        float h2 = Input.GetAxis("Horizontal2");
		//float h1 = - Input.GetAxis ("Mouse X");
		//float h2 = Input.GetAxis("Mouse X");
        if (h2 != 0f)
        {
            animator.SetFloat("Turn", h2/2);
        }
        else if(h1 != 0f)
        {
            animator.SetFloat("Turn", h1);
        }
        else
        {
            animator.SetFloat("Turn", 0f);
        }

		jumpTime += Time.deltaTime;

		//if (Input.GetKey (KeyCode.Space) && jumpTime >= 1f && jumping==0) {
		if(voice.soundConvertedData >= 18.0f && jumpTime >= 1f && jumping == 0){
			//Debug.Log ("222"+Time.deltaTime);
			jumpForce = voice.soundConvertedData >= 23.5f ? 9.0f : (voice.soundConvertedData / 3.5f); 
			rb.AddForce (new Vector3(0, jumpForce, 0), ForceMode.Impulse); //这里的7是高度，把这个数字变了就行。
			jumpTime = 0f;
			//animator.SetTrigger ("Jumping");
			jumping = 1;
		}

		//FootStep();
    }

	public RaycastHit test()
	{
		RaycastHit hit;
		Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit);
		return hit;
	}

	public bool IsGrounded()
	{
		return Physics.Raycast(transform.position, new Vector3(0, -1, 0), 0.3f);
	}

	public void FootStep()
	{
		currFootLeft = animator.GetFloat("FootLeft");   // negative to positive
		currFootRight = animator.GetFloat("FootRight"); // positive to negative


		if (IsGrounded() && (currFootLeft > 0 && lastFootLeft <= 0 || currFootRight < 0 && lastFootRight >= 0))
		{
			footStepAudio.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)]);

			if (footStepParticles != null)
			{
				footStepParticles.Play();
			}
		}


		lastFootLeft = currFootLeft;
		lastFootRight = currFootRight;
	}
}
