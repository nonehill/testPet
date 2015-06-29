using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	float speed;
	
	float respawnMin_Y = -2;
	float respawnMax_Y = 1;
	
	void Start ()
	{
		speed = ElementsSpeedManager.instance.levelSpeed;
	}
	
	void Update ()
	{
		transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);
		
		if (transform.position.x <= -5)
			transform.position = new Vector3 (Random.Range(20, 40), Random.Range(respawnMin_Y, respawnMax_Y), 0);
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "Player")
		{
			GetComponentInChildren<Renderer> ().enabled = false;
			RespawnPowerup();
		}
		
		if (other.tag == "CoinDestroyer") 
		{
			RespawnPowerup();
		}
	}

	void RespawnPowerup()
	{
		GetComponentInChildren<Renderer> ().enabled = true;
		transform.position = new Vector3 (Random.Range(20, 80), Random.Range(-2, 3), 0);
	}
}
