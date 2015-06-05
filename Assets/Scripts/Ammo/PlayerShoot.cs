using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject rocket;

	public void ShootPressed ()
	{

//		if (AmmoManager.canShootRocket)
//		{
			rocket.SetActive (true);
			rocket.GetComponent<Rigidbody2D>().velocity = new Vector2(40, 0);
			rocket.GetComponent<Rigidbody2D>().isKinematic = false;
//		}
	}
}
