using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	Vector3 originalPos;
	float speed;

	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.CompareTag ("Player"))
		{
			HUD.UpdateCoinsScore(CompareTag("SilverCoin") ? 1 : 3);
			Destroy(transform.parent.gameObject);
		}

		if (other.CompareTag ("CoinDestroyer"))
		{
			Destroy(transform.parent.gameObject);
		}
	}

}
