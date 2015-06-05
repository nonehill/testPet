using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player") || other.CompareTag ("Ammo"))
		{
			float damage = 0;
			Debug.Log("shoot the enemy");
			other.GetComponent<Renderer>().enabled = false;

			switch (AmmoManager.ammotype)
			{
			case AmmoType.Gun:
				damage = 50;
				break;
					
			case AmmoType.Rocket:
				damage = 100;
				break;
			}		

			EnemyHealth.HitEnemy(damage);


			StartCoroutine(EnemyHit());
		}
	}

	
	IEnumerator EnemyHit ()
	{
		Debug.Log("EnemyHit");
		GetComponent<Renderer> ().enabled = false;

		for (int i = 0; i < 1; i++) 
		{
			yield return new WaitForSeconds(.06f);
			GetComponent<Renderer> ().enabled = true;
			
			yield return new WaitForSeconds(.06f);
			GetComponent<Renderer> ().enabled = false;

			yield return new WaitForSeconds(.06f);
			GetComponent<Renderer> ().enabled = true;
		}
	}
}
