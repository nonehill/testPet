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
		{
			Moving();
		}

		CheckPosition ();
	}

	void Moving ()
	{
		transform.position -= new Vector3 (groundSpeed * Time.deltaTime, 0, 0);
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

	public void StartMoving ()
	{
		Vector3 newPos = PlatformSpawnManager.instance.GetPositionForSpawn();			
		transform.position = new Vector3 (newPos.x + Random.Range(GameConstants.DISTANCE_RIGHT_FOR_SPAWN, GameConstants.DISTANCE_RIGHT_FOR_SPAWN + 5), transform.position.y, transform.position.z);
		move = true;
	}
}
