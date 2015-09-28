using UnityEngine;
using System.Collections;

public class MonsterCollectionCanvas : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
	}
	
	public void Show ()
	{
		anim.SetBool ("showView", true);
	}
	
	public void Hide ()
	{
		anim.SetBool ("showView", false);
	}
}
