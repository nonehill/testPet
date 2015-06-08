using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject rocket;
	public float timeBetweenBullets = 2;
	float time = 2;

	AmmoManager ammoManager;

	void Awake ()
	{
		ammoManager = GameObject.Find("GameManager").GetComponent<AmmoManager> ();
	}

	void Update ()
	{
		time += Time.deltaTime;
	}

	public void ShootPressed ()
	{
		if (time >= timeBetweenBullets)
		{
			time = 0;
			ammoManager.Shoot();
		}
	}
}
