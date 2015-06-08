using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

	bool canUpdateScore = true;

	GameObject spawner;
	GameObject saveCat;


	GameObject spawnPoint;


	// Use this for initialization
	void Start()
	{
		spawner = GameObject.Find ("EnemySpawner");
		spawnPoint = GameObject.Find ("SpawnEnemyHere");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x < Camera.main.transform.position.x - 10 || transform.position.y < Camera.main.transform.position.y - 10 || EnemyHealth.isDead)
		{
			GetComponent<Collider2D>().enabled = true;
			GetComponent<Renderer>().enabled = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;

			if (canUpdateScore)
			{
				Score.UpdateScore();
				canUpdateScore = false;
			}
		}		

		int spawnPoint_X = (int)spawnPoint.transform.position.x;
		int spawner_X = (int)spawner.transform.position.x;

		if (!canUpdateScore && spawnPoint_X == spawner_X) 
		{			
			EnemyHealth.NewEnemyHealth(100, 0);
			transform.position = new Vector3(spawner.transform.position.x, spawner.transform.position.y, 0);		
			GetComponent <Renderer> ().enabled = true;
			canUpdateScore = true;	
		}
	}
}
