using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	private float health = 3;

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("LifeHeart"))
		{	
			health = 3;
			HUD.instance.FullHealth();
			Debug.Log("full health health = " + health);
		}

		if (other.CompareTag("BombTrigger"))
		{
			health --;
			HUD.instance.ReduceHeart();

			if (health <= 0)
				Application.LoadLevelAsync (1);
		}
	}
}
