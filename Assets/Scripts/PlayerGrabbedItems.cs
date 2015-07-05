using UnityEngine;
using System.Collections;

public class PlayerGrabbedItems : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other)
	{			
		if (other.CompareTag("TimeScaller"))
		{
			Debug.Log("TimeScaller");
			Time.timeScale = .5f;
			Invoke("NormalTime", 1);
		}			
	}

	void NormalTime ()
	{
		Time.timeScale = 1;
	}
}
