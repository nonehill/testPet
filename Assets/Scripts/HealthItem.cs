using UnityEngine;
using System.Collections;

public class HealthItem : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			PlayerHealth.instance.IncreaseHealth(1f);
		}
	}
}
