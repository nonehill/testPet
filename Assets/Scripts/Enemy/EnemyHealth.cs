using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float enemyHealth = 100;

	float enemyArmor = 0;

	bool _dead = false;

	public Rigidbody2D goldCoin;
	public Rigidbody2D silverCoin;

	public bool isDead {
		get {
			return _dead;
		}
	}

	// Use this for initialization
	void Start ()
	{
		_dead = false;
	}
	
	public void HitEnemy (float damage)
	{
		enemyHealth += enemyArmor - damage;

		if (enemyHealth <= 0)
		{
			_dead = true;
			for (int i = 0; i < 1; i++)
			{
				int coinValue = Random.Range(0, 5);
				Rigidbody2D monsterCoin = (Rigidbody2D) Instantiate(coinValue == 4 ? goldCoin : silverCoin, transform.position, Quaternion.identity);
				monsterCoin.AddForce(new Vector2(Random.Range(-300, 400), Random.Range(800, 1500)));
			}
		}
	}



	public void NewEnemyHealth (float health, float armor)
	{
		enemyHealth = health;
		enemyArmor = armor;
		_dead = false;
	}
}
