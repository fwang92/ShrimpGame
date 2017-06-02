using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript_copy : MonoBehaviour {

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
	private bool jumping;
	private Vector3 jump;
	private float jumpForce ;
	private float jumpTime;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		speed = 1;
		characterController = GetComponent<CharacterController>();
		//footStepAudio = gameObject.GetComponent<AudioSource>();
		chara = transform;
		oldRagDoll = false;
		deathTime = 0f;
		rb = GetComponent<Rigidbody>();
		jump = new Vector3(0.0f, 2.0f, 0.0f);
		jumping = false;
		jumpTime = 0f;
		//DisableRagdoll();
	}

	// Update is called once per frame
	void Update () {
		jumpTime += Time.deltaTime;

		for (int i = 0; i < 10; ++i)
		{
			if (Input.GetKeyDown("" + i))
			{
				if (i == 0)
				{
					speed = 10;
				}
				else
				{
					speed = i;
				}
			}
		}

		animator.SetFloat("Forward", speed / 10f * Input.GetAxis("Vertical"));

		float h1 = Input.GetAxis("Horizontal");
		float h2 = Input.GetAxis("Horizontal2");
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

		if (deathTime != 0f && Time.time - deathTime > 6f) {
			//animator.SetBool ("isRagDoll", false);
		}

		if (animator.GetBool("isRagDoll") && !oldRagDoll)
		{
			//EnableRagdoll();
			//deathTime = Time.time;
			//oldRagDoll = true;
		}
		if (!animator.GetBool("isRagDoll") && oldRagDoll)
		{
			//DisableRagdoll();
			//oldRagDoll = false;
			//deathTime = 0f;
		}

		if (Input.GetKey (KeyCode.Space) && jumpTime >= 1f) {
			transform.parent.GetComponent<Rigidbody> ().AddForce (new Vector3(0, 7, 0), ForceMode.Impulse);
			jumpTime = 0f;
			//animator.SetTrigger ("Jumping");
			//jumping = true;
		}

		if (IsGrounded ()) {
			jumping = false;
		}

		//FootStep();
	}


	bool IsGrounded()
	{
		return Physics.Raycast(transform.position, Vector3.down, 0.3f);
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

	void EnableRagdoll()
	{
		if (animator.enabled)
		{
			foreach (Rigidbody rb in chara.GetComponentsInChildren<Rigidbody>())
			{
				rb.isKinematic = false;
				rb.detectCollisions = true;
			}
			characterController.enabled = false;
			animator.enabled = false;

			camera.target = chara.Find("Hips");
			footStepAudio.PlayOneShot (footStepAudio.clip);
		}
	}

	void DisableRagdoll()
	{
		if (!animator.enabled)
		{
			// Set camera and Player_Container to ragdoll;
			transform.position = new Vector3(1.3f, 0.1f, 2.4f);
			transform.rotation = new Quaternion (0f, 180f, 0f, transform.rotation.w);
			camera.target = transform;

			foreach (Rigidbody rb in chara.GetComponentsInChildren<Rigidbody>())
			{
				rb.isKinematic = true;
				//rb.detectCollisions = false;
			}
			characterController.enabled = true;
			animator.enabled = true;
		}
	}
}
