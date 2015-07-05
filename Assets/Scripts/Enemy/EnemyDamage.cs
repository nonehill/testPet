using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

	public EnemyHealth enemyHealth;
	public GameObject bomb;

	float timeBetweenDropBomb = 0;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player") || other.CompareTag ("Ammo"))
		{
			float damage = 0;
			other.GetComponent<Renderer>().enabled = false;

			switch (AmmoManager.ammotype)
			{
			case AmmoType.Gun:
				damage = 10;
				break;
					
			case AmmoType.Rocket:
				damage = 20;
				break;
			}		

			enemyHealth.HitEnemy(damage);

			if(!enemyHealth.isDead)
				StartCoroutine(EnemyHit());
		}
	}

	void Update()
	{	
		if (!enemyHealth.isDead) 
		{
			timeBetweenDropBomb += Time.deltaTime;
			if (timeBetweenDropBomb > 5)
					DropBomb ();
		}
	}


	void DropBomb ()
	{
		timeBetweenDropBomb = 0;
		bomb.transform.position = transform.parent.transform.position;
		bomb.SetActive (true);
		bomb.GetComponent<Rigidbody2D> ().AddForce (new Vector2(Random.Range(-50, -200), Random.Range(400, 600)));
	}
	
	IEnumerator EnemyHit ()
	{
		GetComponentInParent<Renderer> ().enabled = false;

		for (int i = 0; i < 1; i++) 
		{
			yield return new WaitForSeconds(.06f);
			GetComponentInParent<Renderer> ().enabled = true;
			
			yield return new WaitForSeconds(.06f);
			GetComponentInParent<Renderer> ().enabled = false;

			yield return new WaitForSeconds(.06f);
			GetComponentInParent<Renderer> ().enabled = true;
		}
	}
}
