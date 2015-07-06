using UnityEngine;
using System.Collections;

public class TimeScallerItem : MonoBehaviour {	
	
	void OnTriggerEnter2D (Collider2D other)
	{			
		if (other.CompareTag("Player"))
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
