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
		int randomIndex = Random.Range(0, 5);
		ActivatePlatform(platformsForSpawn[randomIndex]);
		SetLastPlatfrom(platformsForSpawn[randomIndex]);
		platformsForSpawn.RemoveAt(randomIndex);
	}

	void SetLastPlatfrom (GameObject platform)
	{
		Debug.Log("platfrom = " + GameObject.Find(platform.name + "/QuadPlatform/groundJumpPoint"));

		lastTransform = GameObject.Find(platform.name + "/QuadPlatform/groundJumpPoint").transform;
	}

	void ActivatePlatform (GameObject platform)
	{
		platform.SendMessage("StartMoving");
	}
}
