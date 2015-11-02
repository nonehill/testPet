using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeScallerItem : MonoBehaviour {	

	Slider _indicator;
	bool _powerupActivated = false;

	float _timer = 0;
	float _duration = 1;

	void Awake ()
	{
		_indicator = GameObject.Find ("TimeScallerIndicator").GetComponent <Slider> ();
		_indicator.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D other)
	{			
		if (other.CompareTag("Player"))
		{
			_indicator.gameObject.SetActive (true);
			_powerupActivated = true;
			Time.timeScale = .5f;
		}			
	}

	void Update ()
	{
		if (_powerupActivated) 
		{
			_timer += Time.deltaTime;
			float tempNum = _duration - _timer;
			_indicator.value = tempNum / _duration;

			if (_timer >= _duration)
			{
				_indicator.gameObject.SetActive (false);
				_timer = 0;
				_powerupActivated = false;
				NormalTime ();
			}
		}
	}
	
	void NormalTime ()
	{
		Time.timeScale = 1;
	}
}
