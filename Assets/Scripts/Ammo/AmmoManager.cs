using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AmmoType {
	Gun = 0,
	Rocket = 1
}

public class AmmoManager : MonoBehaviour
{
	public GameObject rocketImage;
	public GameObject gun;

	public GameObject rocket;
	public List<GameObject> gunBullets;

	public static bool bonusWeapon = false;

	public static AmmoType ammotype;

	public float bulletVelocity;

	void Awake ()
	{
		ammotype = AmmoType.Gun;
	}

	public void WeaponGrabed (AmmoType weaponType)
	{
		switch (weaponType)
		{
		case AmmoType.Rocket:
			ammotype = AmmoType.Rocket;
			bonusWeapon = true;
			rocketImage.SetActive(true);
			break;

		case AmmoType.Gun:
			gun.SetActive(true);
			break;
		}
	}

	public void Shoot()
	{
		if (bonusWeapon)
		{ 
			bonusWeapon = false;
			if (ammotype == AmmoType.Rocket)
			{
				rocket.SetActive(true);
				rocket.GetComponent<Rigidbody2D> ().velocity = new Vector2(bulletVelocity, 0);
				rocket.GetComponent<Rigidbody2D> ().isKinematic = false;
				rocketImage.SetActive(false);
			}
		} 
		else 
		{
			for (int i = 0; i < gunBullets.Count; i++)
			{
				GameObject bullet = (GameObject) gunBullets[i];
				
				if (!bullet.activeSelf)
				{
					bullet.SetActive(true);
					bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletVelocity, 0);
					bullet.GetComponent<Rigidbody2D> ().isKinematic = false;
					break;
				}
			}
		}
	}
}
