using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	Vector3 originalPos;

	// Use this for initialization
	void Start ()
	{
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.CompareTag ("Player"))
		{
			Score.UpdateCoinsScore ();
			GetComponent<Renderer>().enabled = false;
		}

		if (other.CompareTag ("CoinDestroyer"))
		{
			Debug.Log("coin destroyer here");
			GetComponent<Renderer>().enabled = true;
			transform.position = new Vector3(transform.position.x + Random.Range(40, 50), Random.Range(-2, 2), 0);
		}
	}

}
