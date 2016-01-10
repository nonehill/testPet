using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	[SerializeField]
	private float groundSpeed;

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
	}

	private void Moving ()
	{
		transform.position -= new Vector3 (groundSpeed * Time.deltaTime, 0, 0);
	}

	public void Stop ()
	{
		_isMoving = false;
		transform.position = new Vector3 (100, transform.position.y, transform.position.z);
	}

	public void Move ()
	{
		_isMoving = true;
 	}
}
