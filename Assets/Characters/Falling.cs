using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {
    GameObject player;
    Animator animator;
    private float preH;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Erika_Archer");
        animator = player.GetComponent<Animator>();
        preH = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        float curH = transform.position.y;
        if (preH-curH > 0.1)
        {
            animator.SetTrigger("Falling");
        }
        preH = curH;
	}
}
