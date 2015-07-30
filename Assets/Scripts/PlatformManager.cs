using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

	[SerializeField]
	private float groundSpeed;

	[SerializeField]
	private float distanceBehindCamera;

	public bool move = false;

	void Start ()
	{
		groundSpeed = ElementsSpeedManager.instance.levelSpeed;
	}

	// Update is called once per frame
	void Update () 
	{
		if (move)
			transform.position -= new Vector3 (groundSpeed * Time.deltaTime, 0, 0);

		CheckPosition ();
	}

	void CheckPosition ()
	{
		if (transform.position.x < distanceBehindCamera)
		{
			move = false;
			transform.position = new Vector3 (100, transform.position.y, transform.position.z);
			PlatformSpawnManager.instance.SpawnNewPlatformAddCurrentToSpawnList(gameObject);
		}
	}

	void StartMoving ()
	{
		Vector3 newPos = PlatformSpawnManager.instance.GetPositionForSpawn();			
		transform.position = new Vector3 (newPos.x + Random.Range(14, 19), transform.position.y, transform.position.z);
		move = true;
	}
}
