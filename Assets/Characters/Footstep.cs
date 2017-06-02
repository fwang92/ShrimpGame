using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour {
	public List<GroundType> grounds = new List<GroundType>();
	public AnimScript controller;
	public string currentGroundType;

	// Use this for initialization
	void Start () {
		setGroundType(grounds[0]);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.transform.tag == "normal")
			setGroundType (grounds [0]);
		else if (hit.transform.tag == "platform")
			setGroundType (grounds [1]);
		else if (hit.transform.tag == "metal")
			setGroundType (grounds [2]);
		else
			setGroundType(grounds[0]);
	}

	public void setGroundType(GroundType ground)
	{
		if (currentGroundType != ground.name)
		{
			controller.footstepSounds = ground.footstepSounds;
			controller.footStepParticles = ground.particles;
			currentGroundType = ground.name;
		}
	}
}

[System.Serializable]
public class GroundType
{
	public string name;

	public AudioClip[] footstepSounds;
	public ParticleSystem particles;
}
