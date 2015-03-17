using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	bool canUpdateScore = true;

	GameObject spawner;

	// Use this for initialization
	void Start()
	{
		spawner = GameObject.Find ("EnemySpawner");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < Camera.main.transform.position.x - 10 || transform.position.y < Camera.main.transform.position.y - 10)
		{
			collider2D.enabled = true;

			if (canUpdateScore)
			{
				Score.UpdateScore();
				canUpdateScore = false;
			}
		}
		if (canUpdateScore == false) 
		{
			transform.position = spawner.transform.TransformPoint(Vector3.zero);
			canUpdateScore = true;
		}
	}
}
