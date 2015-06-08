using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	public GameObject gun;

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Destroyer"))
		{
			GetComponent<Renderer>().enabled = true;
			transform.position = gun.transform.position;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			GetComponent<Rigidbody2D> ().isKinematic = true;
			gameObject.SetActive(false);
		}
	}
}
