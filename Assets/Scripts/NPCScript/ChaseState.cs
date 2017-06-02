using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : INPCState {

	private readonly StatePatternNPC npc;
	Transform playerPosition;

	public ChaseState(StatePatternNPC statePatternNPC) {
		npc = statePatternNPC;
	}


	public void UpdateState () {
		chase ();
	}


	public void OnTriggerEnter (Collider other)
	{

	}


	public void ToPatrolState () {
		npc.currentState = npc.patrolState;
	}


	public void ToChaseState ()
	{

	}

	private void chase() {
		
	}
}
