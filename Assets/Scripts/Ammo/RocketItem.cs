using UnityEngine;
using System.Collections;

public class RocketItem : MonoBehaviour {
		
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "Player")
		{
		   	GetComponent<Renderer> ().enabled = false;
		}

		if (other.tag == "CoinDestroyer") 
		{
			Debug.Log("Destroy rocket");
		}
	}

}
