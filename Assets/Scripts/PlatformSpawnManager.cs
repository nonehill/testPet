using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawnManager : MonoBehaviour {

	public List<GameObject> platformsForSpawn;
	public static PlatformSpawnManager instance;

	private Transform _firstPlatform;
	private Transform _lastPlatform;

	public List<GameObject> _movingPlatforms;
	public List<GameObject> _notMovingPlatforms;

	// Use this for initialization
	void Awake ()
	{
		instance = this;
	}

	void Start ()
	{
		_movingPlatforms = new List<GameObject>();
		_notMovingPlatforms = new List<GameObject>();
		_notMovingPlatforms.AddRange(platformsForSpawn);
		SetPlatformsOnStart ();
	}

	private void SetPlatformsOnStart ()
	{
		for (int i = 0; i < platformsForSpawn.Count / 2; i++)
		{
			ActivatePlatform(platformsForSpawn[i]);
		}

		_firstPlatform = _movingPlatforms[0].transform;
	}

	void Update ()
	{
		if (_firstPlatform.position.x <= GameConstants.MIN_X_FOR_REMOVE)
		{
			GameObject _removePlatform = _firstPlatform.gameObject;
			_movingPlatforms.Remove(_removePlatform);
			_notMovingPlatforms.Add(_removePlatform);
			_firstPlatform = _movingPlatforms[0].transform;
			GetRandomPlatform();
		}
	}

	private void GetRandomPlatform ()
	{
		int randomPlatformNum = Random.Range (0, _notMovingPlatforms.Count);
		GameObject randomPlatform = _notMovingPlatforms[randomPlatformNum];
		ActivatePlatform (randomPlatform);
	}

	private void ActivatePlatform (GameObject platform)
	{
		Vector3 newPosition = Vector3.zero;

		if (_lastPlatform == null) 
		{
			newPosition = platform.transform.position;
		}
		else
		{
			foreach (Transform child in _lastPlatform)
			{
				foreach (Transform childTransform in child)
				{
					if (childTransform.tag == "JumpPoint")
					{
						newPosition = new Vector3 ();
					}
				}
			}
		}

		platform.transform.position = newPosition;
		platform.GetComponent<Platform>().Move();
		_movingPlatforms.Add(platform);
		_notMovingPlatforms.Remove(platform);
		_lastPlatform = platform.transform;		
	}

}
