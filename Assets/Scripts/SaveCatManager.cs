using UnityEngine;
using System.Collections;

public class SaveCatManager : MonoBehaviour 
{
	Animator anim;

	// Use this for initialization
	void Star() 
	{
		anim = GetComponent<Animator>();
	}
	
	void Run()
	{
		Debug.Log ("Im called" + anim);
	
		anim.SetBool ("run", true);
	}

	void StopRun()
	{
		anim.SetBool ("run", false);
	}
}
