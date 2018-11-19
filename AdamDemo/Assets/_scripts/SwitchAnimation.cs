using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimation : MonoBehaviour {


	public Animator anim;

	void Awake()
	{
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.anyKey) {
			anim.SetInteger("walk",1);
		} else {
			anim.SetInteger("walk",0);
		}

		/*  This is how you would do it with Triggers
			you need to remove the Integer trigger to make this work

		if (Input.anyKey){
			anim.SetTrigger("walking");
			anim.ResetTrigger("stopWalking");
		} else {
			anim.SetTrigger("stopWalking");
			anim.ResetTrigger("walking");
		}
		*/
	}
}
