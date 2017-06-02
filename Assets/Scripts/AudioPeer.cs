using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour {
	AudioSource audioSource;
	public float[] samples = new float[1024];
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		GetSpectrumAduioSource ();
		
	}
	void GetSpectrumAduioSource(){
		audioSource.GetSpectrumData (samples, 0, FFTWindow.Rectangular);
		for (int i = 1; i < samples.Length - 1; i++) {
			Debug.DrawLine(new Vector3(i - 1, samples[i] + 10, 0), new Vector3(i, samples[i + 1] + 10, 0), Color.red);
			Debug.DrawLine(new Vector3(i - 1, Mathf.Log(samples[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(samples[i]) + 10, 2), Color.cyan);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), samples[i - 1] - 10, 1), new Vector3(Mathf.Log(i), samples[i] - 10, 1), Color.green);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(samples[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(samples[i]), 3), Color.blue);
		}

	}
}
