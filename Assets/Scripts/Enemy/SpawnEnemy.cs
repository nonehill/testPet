using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

	bool canUpdateScore = true;

	GameObject spawner;
	GameObject saveCat;

	GameObject spawnPoint;
	public EnemyHealth enemyHealth;

	[SerializeField]
	float timeSpawnAfterDeath;

	float time;

	int enemyStrongProgress = 0; 

	int baseHealth = 20;

	bool createEnemy = false;

	public GameObject enemy;
	public bool checkGroundForSpawn = false;

	public Transform startRay;
	public Transform endRay;

	// Use this for initialization
	void Start()
	{
		spawner    = GameObject.Find ("EnemySpawner");
		spawnPoint = GameObject.Find ("SpawnEnemyHere");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (enemyHealth.isDead)
			createEnemy = true;

		if (createEnemy)
		{	
			time += Time.deltaTime;
			enemy.GetComponent<Collider2D>().enabled = true;
			enemy.GetComponent<Renderer>().enabled = false;
			enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

			if (canUpdateScore)
			{
				HUD.UpdateScore();
				canUpdateScore = false;
			}
		}		

		checkGroundForSpawn = Physics2D.Linecast(startRay.position, endRay.position, 1 << LayerMask.NameToLayer ("Ground"));

		if ((!canUpdateScore && time >= timeSpawnAfterDeath || enemy.transform.position.y <= -3.5f) && checkGroundForSpawn)
		{			
			time = 0;

			enemyStrongProgress++;

			if (enemyStrongProgress > 3)
			{
				enemyStrongProgress = 0;
				baseHealth += 10;
			}

			Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
			enemy.GetComponent<Renderer>().material.color = newColor; 

			createEnemy = false;
			enemyHealth.NewEnemyHealth(baseHealth, 0);
			enemy.transform.position = new Vector3(spawner.transform.position.x, spawner.transform.position.y, 0);		
			enemy.GetComponent <Renderer> ().enabled = true;
			canUpdateScore = true;	
		}
	}
}
