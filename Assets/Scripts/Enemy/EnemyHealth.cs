using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public static float enemyHealth = 100;

	static float enemyArmor = 0;

	static bool _dead = false;

	public static bool isDead {
		get {
			return _dead;
		}
	}

	// Use this for initialization
	void Start ()
	{
		_dead = false;
	}
	
	public static void HitEnemy (float damage)
	{
		enemyHealth += enemyArmor - damage;

		if (enemyHealth <= 0)
		{
			_dead = true;
		}
	}

	public static void NewEnemyHealth (float health, float armor)
	{
		enemyHealth = health;
		enemyArmor = armor;
		_dead = false;
	}
}
