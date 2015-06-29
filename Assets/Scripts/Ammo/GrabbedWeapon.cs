using UnityEngine;
using System.Collections;

public class GrabbedWeapon : MonoBehaviour {

	public AmmoType weaponType;
	AmmoManager ammoManager;

	void Awake ()
	{
		ammoManager = GameObject.Find ("GameManager").GetComponent<AmmoManager> ();
	}
	
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "Player")
		{
			GetComponentInChildren<Renderer> ().enabled = false;
			ammoManager.WeaponGrabed(weaponType);	
			RespawnRocket();
		}
		
		if (other.tag == "CoinDestroyer") 
		{
			RespawnRocket();
		}
	}

	void RespawnRocket()
	{
		GetComponentInChildren<Renderer> ().enabled = true;
		transform.position = new Vector3 (Random.Range(20, 40), Random.Range(-2, 1), 0);
	}
}
