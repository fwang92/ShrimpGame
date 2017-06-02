using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatePatternNPC : MonoBehaviour {

	public Transform[] wayPoints;
	 

	//public Transform player;

	public AINavSteeringController aiSteer;

	[HideInInspector] public INPCState currentState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public NavMeshAgent navMeshAgent;

	 


	private void Awake ()
	{
		patrolState = new PatrolState (this);
		chaseState = new ChaseState (this);

		navMeshAgent = GetComponent<NavMeshAgent> ();
	}


	// Use this for initialization
	void Start () 
	{

		//currentState = patrolState;

		aiSteer = GetComponent<AINavSteeringController> ();
		aiSteer.Init();

		aiSteer.stopAtNextWaypoint = false;
		aiSteer.useNavMeshPathPlanning = false;

		transitionToStatePatrol ();
	}

	void transitionToStatePatrol() {

		print("Transition to state A");

		currentState = patrolState;

		aiSteer.setWayPoints(wayPoints);

		aiSteer.useNavMeshPathPlanning = true;


	}

	// Update is called once per frame
	void Update () 
	{
		//currentState.UpdateState ();
		if (aiSteer.waypointsComplete ()) {

		}
	}


	private void OnTriggerEnter (Collider other)
	{
		currentState.OnTriggerEnter (other);
	}
}