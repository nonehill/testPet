using UnityEngine;
using System.Collections;

public class PlayerGrabbedItems : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other)
	{			
		if (other.gameObject.CompareTag("TimeScaller"))
		{
			Time.timeScale = .5f;
			Invoke("NormalTime", 1);
		}			
	}

	void NormalTime ()
	{
		Time.timeScale = 1;
	}
}
