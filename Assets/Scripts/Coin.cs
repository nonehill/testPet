using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	Vector3 originalPos;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.CompareTag ("Player"))
		{
			Score.UpdateCoinsScore(CompareTag("SilverCoin") ? 1 : 3);
			Destroy(transform.parent.gameObject);
		}

		if (other.CompareTag ("CoinDestroyer"))
		{
			Destroy(transform.parent.gameObject);
		}
	}

}
