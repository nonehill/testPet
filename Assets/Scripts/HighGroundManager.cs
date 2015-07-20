using UnityEngine;
using System.Collections;

public class HighGroundManager : MonoBehaviour {

	Vector3 originalPos;
	public float max_Y = 2;
	public float min_Y = -1.5f;

	public float distanceBehindCmaraRespawn = -7;

	[SerializeField]
	private float highGroundSpeed;

	public float max_X;
	public float min_X;

	// Use this for initialization
	void Start () 
	{
		highGroundSpeed = ElementsSpeedManager.instance.levelSpeed;
		originalPos = transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position -= new Vector3 (highGroundSpeed * Time.deltaTime, 0, 0);

		if (transform.position.x <= distanceBehindCmaraRespawn)
			transform.position = new Vector3 (Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), transform.position.z);
	}
}
