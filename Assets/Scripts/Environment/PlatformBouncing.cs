using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformBouncing : MonoBehaviour {

	Animator anim;
	public List<ParticleSystem> flinders;

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("Player") || other.CompareTag("enemy"))
		{
			anim.SetTrigger("bouncing");

			bool particleGo = false;

			if (gameObject.name == "platform")
			{
				for (int i = 0; i < flinders.Count; i++)
				{
					ParticleSystem flinder = (ParticleSystem) flinders[i];

					if (!flinder.isPlaying && !particleGo)
					{
						particleGo = true;
						flinder.gameObject.transform.SetParent(transform);
						Vector3 newPos = gameObject.transform.position;
						flinder.gameObject.transform.position = new Vector3(newPos.x, newPos.y - .3f, newPos.z);
						flinder.Play();
						StartCoroutine(StopParticle(flinder, .5f));
						break;
					}
				}
			}
		}
	}	 

	IEnumerator StopParticle(ParticleSystem particle, float timeDelay)
	{
		yield return new WaitForSeconds (timeDelay);
		particle.Stop();
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag("Player") || other.CompareTag("enemy"))		
			if (gameObject.name == "platform")		
				anim.SetTrigger("stopBouncing");
	}
}
