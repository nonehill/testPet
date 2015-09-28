using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	Animator anim;
	public GameObject canvas;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent <Animator> ();
	}
	
	public void StartHide ()
	{
		anim.SetTrigger ("fade");
	}

	public void ShowButtons ()
	{
		canvas.SetActive (true);
	}
}
