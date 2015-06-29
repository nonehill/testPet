using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundImage : MonoBehaviour {

	[SerializeField]
	private float backgroundSpeed = 10;
	
	[SerializeField]
	private float distanceBehindCamera;

	public List<Sprite> backgroundList;

	private int backgroundCount = 0;
	
	// Use this for initialization
	void Start ()
	{
		backgroundSpeed = ElementsSpeedManager.instance.levelSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position -= new Vector3 (backgroundSpeed * Time.deltaTime, 0, 0);
		if (transform.position.x < -distanceBehindCamera)
		{
			transform.position = new Vector3 (26.68f, transform.position.y, transform.position.z);
			backgroundCount++;

			if (backgroundCount >= 4) 
			{
				Debug.Log("Change back");
				backgroundCount = 0;
			}
		}

	
	}
}
