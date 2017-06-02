using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : INPCState {

	private readonly StatePatternNPC npc;

	Transform[] waypointSetA;

	public PatrolState(StatePatternNPC statePatternNPC) {
		
		npc = statePatternNPC;
		waypointSetA  = npc.wayPoints; 

		Debug.Log ("length:");
		Debug.Log (waypointSetA.Length);
	}
	

	public void UpdateState () {
		Debug.Log ("Patrol");
		Patrol ();
	}


	public void OnTriggerEnter (Collider other)
	{
		
	}


	public void ToPatrolState () {
		Debug.Log ("Can't transition to same state");
	}


	public void ToChaseState ()
	{
		//npc.currentState = npc.chaseState;
	}

	private void Patrol ()
	{
		npc.aiSteer.setWayPoints (waypointSetA);
	}
}
