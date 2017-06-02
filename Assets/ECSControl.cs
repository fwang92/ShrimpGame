using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECSControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void clickreturn()
	{
		Time.timeScale = 1;
		transform.gameObject.SetActive (false);
	}

	public void clickexit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}
}
