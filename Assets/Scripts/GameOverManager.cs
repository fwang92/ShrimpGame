using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public float restartDelay = 5f;         // Time to wait before restarting the level


	Animator anim;                          // Reference to the animator component.
	float restartTimer;                     // Timer to count up to restarting the level
	private bool over;
	private bool pass;


	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
		over = false;
		pass = false;
	}

	void Update ()
	{
		if (pass) {
			// .. increment a timer to count up to restarting.
			restartTimer += Time.deltaTime;

			// .. if it reaches the restart delay...
			if (restartTimer >= restartDelay) {
				pass = false;
				// .. then reload the currently loaded level.
				#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
				#else
				Application.Quit();
				#endif
			}
		}
		else if (over) {
			// .. increment a timer to count up to restarting.
			restartTimer += Time.deltaTime;

			// .. if it reaches the restart delay...
			if (restartTimer >= restartDelay) {
				over = false;
				// .. then reload the currently loaded level.
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	public void GameOver ()
	{
		// ... tell the animator the game is over.
		anim.SetTrigger ("GameOver");

		over = true;
	}

	public void GamePass() {
		GameObject.Find ("GameOverText").GetComponent<Text> ().text = "Congradulations! You win!";

		anim.SetTrigger ("GameOver");

		pass = true;
	}
}
