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
			GetComponent<Renderer> ().enabled = false;
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
		GetComponent<Renderer> ().enabled = true;
		transform.parent.transform.position = new Vector3(transform.parent.position.x + 100, Random.Range(-2, 2), 0);
	}
}
