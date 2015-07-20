using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

	[SerializeField]
	private float groundSpeed;

	[SerializeField]
	private float distanceBehindCamera;

	void Start ()
	{
		groundSpeed = ElementsSpeedManager.instance.levelSpeed;
	}

	// Update is called once per frame
	void Update () 
	{
		transform.position -= new Vector3 (groundSpeed * Time.deltaTime, 0, 0);

		if (transform.position.x < -distanceBehindCamera)
		{
			Vector3 newPos = PlatformSpawnManager.instance.GetNewPosition();			
			transform.position = new Vector3 (newPos.x + 15, transform.position.y, transform.position.z);
			PlatformSpawnManager.instance.SetLastPlatformTransform();
		}
	}
}
