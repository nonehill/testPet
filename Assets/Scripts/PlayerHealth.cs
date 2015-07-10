using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	private float health = 3;

	public static PlayerHealth instance;

	void Start ()
	{
		instance = this;
	}

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("BombTrigger"))
		{
			health --;
			HUD.instance.DisableHeart();

			if (health <= 0)
			{
				CanvasManager.instance.ShowDeathPanel();
				gameObject.SetActive(false);
			}
		}
	}

	public void IncreaseHealth (float healthAmount)
	{
		if (health < 3)
		{
			health += healthAmount;
			HUD.instance.EnableHeart();
		}
	}
}
