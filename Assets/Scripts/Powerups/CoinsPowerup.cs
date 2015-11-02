using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinsPowerup : MonoBehaviour {

	float _timer = 0;
	float _duraration = 15;
	private bool _poweupActivated = false;
	public bool powerupActivated
	{
		get 
		{
			return _poweupActivated;
		}
	}

	public Slider indicator;

	void Awake ()
	{
		indicator = GameObject.Find ("PowerupIndicator").GetComponent <Slider>(); 
		indicator.gameObject.SetActive (false);
	}

	void Start ()
	{
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player"))
		{
			indicator.gameObject.SetActive(true);
			_poweupActivated = true;
			PowerupManager.instance.coinMagnetActivated = _poweupActivated;
		}
	}

	void Update ()
	{
		if (_poweupActivated)
		{
			_timer += Time.deltaTime;
			float tempNum = _duraration - _timer;
			indicator.value = tempNum / _duraration;

			if (_timer >= _duraration)
			{
				indicator.gameObject.SetActive(false);
				_poweupActivated = false;
				_timer = 0;
				PowerupManager.instance.coinMagnetActivated = _poweupActivated;
			}
		}
	}
}
