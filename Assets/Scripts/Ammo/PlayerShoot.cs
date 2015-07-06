using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public float timeBetweenBullets = 2;
	float time = 2;

	AmmoManager ammoManager;

	bool fire = false;

	void Awake ()
	{
		ammoManager = GameObject.Find("GameManager").GetComponent<AmmoManager> ();
	}

	void Update ()
	{
		time += Time.deltaTime;

		if (fire)
		{
			if (time >= timeBetweenBullets)
			{
				time = 0;
				ammoManager.Shoot();
			}
		}	
	}

	public void Fire ()
	{
		fire = true;
	}

	public void StopFire ()
	{
		fire = false;
	}
}
