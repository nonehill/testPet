using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

	[SerializeField]
	private float groundSpeed;

	[SerializeField]
	private float distanceBehindCamera;

	public float respawnFroundPosX = 70;

	void Start ()
	{
		groundSpeed = ElementsSpeedManager.instance.levelSpeed;
	}

	// Update is called once per frame
	void Update () 
	{
		transform.position -= new Vector3 (groundSpeed * Time.deltaTime, 0, 0);

		if (transform.position.x < -distanceBehindCamera)
			transform.position = new Vector3 (respawnFroundPosX , transform.position.y, transform.position.z);
	}
}
