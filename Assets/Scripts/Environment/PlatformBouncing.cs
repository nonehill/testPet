using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformBouncing : MonoBehaviour {

	Animator anim;
	public List<GameObject> flinders;

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("Player") || other.CompareTag("enemy"))
		{
			anim.SetTrigger("bouncing");

			if (gameObject.name == "platform")
			{
				for (int i = 0; i < flinders.Count; i++)
				{
					GameObject flinder = (GameObject) flinders[i];
					if (!flinder.activeSelf)
					{
						flinder.transform.SetParent(transform);
						Vector3 newPos = gameObject.transform.position;
						flinder.transform.position = new Vector3(Random.Range(newPos.x - 1.5f, newPos.x + 1.5f), newPos.y, newPos.z);
						flinder.SetActive(true);
						StartCoroutine(DisableFlinders(flinder, 1f));
						break;
					}
				}
			}
		}
	}	 

	IEnumerator DisableFlinders (GameObject flinder, float delay)
	{
		yield return new WaitForSeconds(delay);
		flinder.transform.parent = null;
		flinder.SetActive(false);
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag("Player") || other.CompareTag("enemy"))		
			if (gameObject.name == "platform")		
				anim.SetTrigger("stopBouncing");
	}
}
