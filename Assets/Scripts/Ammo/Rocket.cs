using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	public GameObject gun;

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Destroyer"))
		{
			transform.position = gun.transform.position;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			GetComponent<Rigidbody2D> ().isKinematic = true;
			GetComponent<Renderer>().enabled = true;
//			gameObject.SetActive(false);
		}
	}

}
