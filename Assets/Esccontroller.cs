using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esccontroller : MonoBehaviour {
	public GameObject EcsManu;
	// Use this for initialization
	void Start () {
		EcsManu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			EcsManu.SetActive (true);
			Time.timeScale = 0;
		}


	}
}
