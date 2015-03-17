using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	Vector3 originalPos;

	// Use this for initialization
	void Start () {
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) 
	{

		renderer.enabled = false;

		if(other.CompareTag("Player"))
			Score.UpdateCoinsScore ();
	}

	void Update()
	{
		if (transform.position.x < Camera.main.transform.position.x - 10) 
		{
			renderer.enabled = true;
			transform.position = new Vector3(transform.position.x + Random.Range(20, 30), Random.Range(-2, 2), 0);
		}
	}
}
