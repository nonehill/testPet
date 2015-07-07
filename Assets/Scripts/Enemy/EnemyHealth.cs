using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float enemyHealth = 100;

	float enemyArmor = 0;

	bool _dead = false;

	public Rigidbody2D goldCoin;
	public Rigidbody2D silverCoin;

	int countOfDeathAndAmountCoinsChange = 0;

	int coinsFromEnemyDeath = 3;

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
			transform.parent.gameObject.SetActive(false);
			for (int i = 0; i < coinsFromEnemyDeath; i++)
			{
				SpawnCoin ();
			}
			return;
		}
		SpawnCoin ();

	}

	void SpawnCoin ()
	{
		int coinValue = Random.Range(0, 5);
		Rigidbody2D monsterCoin = (Rigidbody2D) Instantiate(coinValue == 4 ? goldCoin : silverCoin, transform.position, Quaternion.identity);
		monsterCoin.transform.SetParent(GameObject.Find ("CoinParent").transform);
		monsterCoin.AddForce(new Vector2(Random.Range(-200, 450), Random.Range(800, 1200)));
	}


	public void NewEnemyHealth (float health, float armor)
	{
		transform.parent.gameObject.SetActive(true);

		countOfDeathAndAmountCoinsChange ++;

		if (countOfDeathAndAmountCoinsChange >= 3) 
		{
			countOfDeathAndAmountCoinsChange = 0;
			coinsFromEnemyDeath++;
		}

		transform.parent.transform.position = Vector3.zero;
		enemyHealth = health;
		enemyArmor = armor;
		_dead = false;
	}
}
