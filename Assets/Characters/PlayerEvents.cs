﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour {
	private UnityAction someListener;

	void Awake()
	{
		someListener = new UnityAction (death);
	}

	void OnEnable ()
	{
		EventManager.StartListening ("death", someListener);
	}

	void OnDisable ()
	{
		EventManager.StopListening ("death", someListener);
	}

	void death()
	{
		Animator animator = GetComponent<Animator>();
		animator.SetBool ("isRagDoll", true);
	}
} 