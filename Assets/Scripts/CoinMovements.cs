using UnityEngine;
using System.Collections;

public class CoinMovements : MonoBehaviour {

	public GameObject playerTarget;

	void Start ()
	{
		playerTarget = GameObject.Find ("Player");
	}

	void Update ()
	{
		if (PowerupManager.instance.coinMagnetActivated)
		{
			transform.position = Vector3.MoveTowards (transform.position, playerTarget.transform.position, 10 * Time.deltaTime);
		}
	}
}
