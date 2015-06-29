using UnityEngine;
using System.Collections;

public class CoinParent : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start ()
	{
		speed = ElementsSpeedManager.instance.levelSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);
	}
}
