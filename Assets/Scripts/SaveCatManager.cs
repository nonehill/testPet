using UnityEngine;
using System.Collections;

public class SaveCatManager : MonoBehaviour 
{
	Animator animator;
	bool run = false;
	void OnEnable() 
	{
		animator = GetComponent<Animator> ();
		GetComponent<Collider2D>().enabled = false;
	}
	
	void Run()
	{
		run = true;
		animator.SetBool ("run", true);
		transform.parent = null;
		GetComponent<Collider2D>().enabled = true;
		GetComponent<Rigidbody2D>().isKinematic = false;
	}

	void Update()
	{
		if (run)
			transform.position -= Vector3.right * 5 * Time.deltaTime;
	}

	void StopRun()
	{
		run = false;
		animator.SetBool ("run", false);
		transform.parent = GameObject.Find ("Enemy").transform;
		transform.localPosition = new Vector3(.4f, .8f, 0);
		GetComponent<Rigidbody2D>().isKinematic = true;
		GetComponent<Collider2D>().enabled = false;
		transform.localPosition = new Vector3(.4f, .8f, 0);
	}
}
