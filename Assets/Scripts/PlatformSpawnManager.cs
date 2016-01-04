using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawnManager : MonoBehaviour {

	public List<GameObject> platformsForSpawn;
	public static PlatformSpawnManager instance;

	public Transform lastTransform;

	// Use this for initialization
	void Awake ()
	{
		instance = this;
	}

	void Start ()
	{
		SetPlatformsOnStart ();
	}

	private void SetPlatformsOnStart ()
	{
		for (int i = 0; i < platformsForSpawn.Count; i++)
		{
			Vector3 newPosition = new Vector3(GameConstants.DISTANCE_BETWEEN_PLATFORMS * i, platformsForSpawn[i].transform.position.y, platformsForSpawn[i].transform.position.z);
			platformsForSpawn[i].transform.position = newPosition;
			lastTransform = platformsForSpawn[i].transform;
		}
	}

	public Vector3 GetPositionForSpawn ()
	{
		Vector3 v3 = new Vector3(lastTransform.position.x, lastTransform.position.y, lastTransform.position.z);
		return v3;
	}

	public void SpawnNewPlatformAddCurrentToSpawnList(GameObject newPlatform)
	{
		SpawnRandomPlatform();
		platformsForSpawn.Add(newPlatform);
	}

	void SpawnRandomPlatform ()
	{
		int randomIndex = Random.Range(0, platformsForSpawn.Count);
		ActivatePlatform(platformsForSpawn[randomIndex]);
		platformsForSpawn.RemoveAt(randomIndex);
	}

	void SetLastPlatfrom (GameObject platform)
	{
		lastTransform = GameObject.Find(platform.name + "/QuadPlatform/groundJumpPoint").transform;
	}

	void ActivatePlatform (GameObject platform)
	{
		SetLastPlatfrom(platform);
		platform.SendMessage("StartMoving");
	}
}
