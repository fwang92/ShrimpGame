using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCState {

	void UpdateState ();

	void OnTriggerEnter (Collider other) ;

	void ToPatrolState ();

	void ToChaseState ();
}