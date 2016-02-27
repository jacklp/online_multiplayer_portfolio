using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour{

	public float speed;
	public Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{

		if(Input.GetKey(KeyCode.A)){
			anim.SetBool("Left", true);
			anim.SetBool("Up", false);
			anim.SetBool("Right", false);
			anim.SetBool("Down", false);
		}

		if(Input.GetKey(KeyCode.W)){
			anim.SetBool("Up", true);
			anim.SetBool("Down", false);
			anim.SetBool("Left", false);
			anim.SetBool("Right", false);
		}

		if(Input.GetKey(KeyCode.D)){
			anim.SetBool("Right", true);
			anim.SetBool("Left", false);
			anim.SetBool("Up", false);
			anim.SetBool("Down", false);
		}

		if(Input.GetKey(KeyCode.S)){
			anim.SetBool("Down", true);
			anim.SetBool("Left", false);
			anim.SetBool("Right", false);
			anim.SetBool("Up", false);
		}

		if (Input.GetKey (KeyCode.A)) {
			anim.SetBool ("WalkLeft", true);
		} else {
			anim.SetBool ("WalkLeft", false);
		}

		if (Input.GetKey (KeyCode.W)) {
			anim.SetBool ("WalkUp", true);
		} else {
			anim.SetBool ("WalkUp", false);
		}

		if (Input.GetKey (KeyCode.D)) {
			anim.SetBool ("WalkRight", true);
		} else {
			anim.SetBool ("WalkRight", false);
		}

		if (Input.GetKey (KeyCode.S)) {
			anim.SetBool ("WalkDown", true);
		} else {
			anim.SetBool ("WalkDown", false);
		}

	}
}


