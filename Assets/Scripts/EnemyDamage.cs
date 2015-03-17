using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

	GameObject stolenCat;

	// Use this for initialization
	void Start () {
		stolenCat = GameObject.Find ("save cat");
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			collider2D.enabled = false;
			stolenCat.SendMessage("StopRun");
		}
	}
}
