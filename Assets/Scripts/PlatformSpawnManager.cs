using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawnManager : MonoBehaviour {

	public List<GameObject> platformsForSpawn;
	public static PlatformSpawnManager instance;

	public GameObject _firstPlatform;
	public GameObject _lastPlatform;

	public List<GameObject> _movingPlatforms;
	public List<GameObject> _notMovingPlatforms;

	// Use this for initialization
	void Awake ()
	{
		instance = this;
		_firstPlatform = platformsForSpawn[0];

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
		for (int i = 0; i < platformsForSpawn.Count - 2; i++)
		{
			ActivatePlatform(platformsForSpawn[i]);
		}
	}

	void Update ()
	{
		if (_firstPlatform.transform.position.x <= GameConstants.MIN_X_FOR_REMOVE)
		{
			GameObject _removePlatform = _firstPlatform;
			_removePlatform.GetComponent<Platform>().Stop();
			_movingPlatforms.Remove(_removePlatform);
			_notMovingPlatforms.Add(_removePlatform);
			_firstPlatform = _movingPlatforms[0];
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
			newPosition = new Vector3(4, -3f, 0);

		}
		else
		{
			Transform _lastPaltformRightEdge = _lastPlatform.transform.FindChild("PlatfromTrigger/rightEdge").transform;

			Transform _newPlatformLeftEdge = platform.transform.FindChild("PlatfromTrigger/leftEdge").transform;
			Transform _newPlatformRightEdge = platform.transform.FindChild("PlatfromTrigger/rightEdge").transform;

			float _newPlatformLength = Mathf.Abs(_newPlatformLeftEdge.localPosition.x) + Mathf.Abs(_newPlatformRightEdge.localPosition.x); 

			newPosition = new Vector3(_lastPaltformRightEdge.position.x + _newPlatformLength / 2 + 5, -3.41f, 0);
		}

		platform.transform.position = newPosition;
		platform.GetComponent<Platform>().Move();
		_movingPlatforms.Add(platform);
		_notMovingPlatforms.Remove(platform);
		_lastPlatform = platform;		
	}
}
