using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	[SerializeField]
	private float groundSpeed;

	[SerializeField]
	private float distanceBehindCamera;

	private bool _isMoving = false;

	[SerializeField]
	public bool isMoving
	{
		get {return _isMoving;}
		set {_isMoving = value;}
	}

	public bool move = false;

	void Start ()
	{
		groundSpeed = ElementsSpeedManager.instance.levelSpeed;
	}

	// Update is called once per frame
	private void Update () 
	{
		if (isMoving)
		{
			Moving();
		}

		CheckPosition ();
	}

	private void Moving ()
	{
		transform.position -= new Vector3 (groundSpeed * Time.deltaTime, 0, 0);
	}

	private void CheckPosition ()
	{
		if (transform.position.x < distanceBehindCamera)
		{
			_isMoving = false;
			transform.position = new Vector3 (100, transform.position.y, transform.position.z);
		}
	}

	public void Move ()
	{
		_isMoving = true;
 	}

//	public void StartMoving ()
//	{
//		Vector3 newPos = PlatformSpawnManager.instance.GetPositionForSpawn();			
//		transform.position = new Vector3 (newPos.x + Random.Range(GameConstants.DISTANCE_RIGHT_FOR_SPAWN, GameConstants.DISTANCE_RIGHT_FOR_SPAWN + 5), transform.position.y, transform.position.z);
//		_isMoving = true;
//	}
}
