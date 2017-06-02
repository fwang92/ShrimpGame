using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {

	public void OnTriggerEnter(Collider col)
	{
		EventManager.TriggerEvent ("death");
	}
}
