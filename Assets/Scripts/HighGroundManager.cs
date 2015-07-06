using UnityEngine;
using System.Collections;

public class HighGroundManager : MonoBehaviour {

	Vector3 originalPos;
	public float max_Y = 2;
	public float min_Y = -1.5f;

	[SerializeField]
	private float highGroundSpeed = 10;

	// Use this for initialization
	void Start () 
	{
		highGroundSpeed = ElementsSpeedManager.instance.levelSpeed;
		originalPos = transform.position;
	}
	
//	void OnTriggerEnter2D (Collider2D other)
//	{
//		if (other.CompareTag("Player"))
//		{
//			Debug.Log("Player Here");
//		}
//	}

	// Update is called once per frame
	void Update ()
	{
		transform.position -= new Vector3 (highGroundSpeed * Time.deltaTime, 0, 0);

		if (transform.position.x <= -5)
			transform.position = new Vector3 (Random.Range(15, 25), Random.Range(min_Y, max_Y), transform.position.z);
	}
}
