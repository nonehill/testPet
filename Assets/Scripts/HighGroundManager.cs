using UnityEngine;
using System.Collections;

public class HighGroundManager : MonoBehaviour {

	Vector3 originalPos;
	public float max_Y = 2;
	public float min_Y = -1.5f;

	// Use this for initialization
	void Start () 
	{
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x < Camera.main.transform.position.x - 25)
			transform.position = new Vector3 (transform.position.x + Random.Range(40, 60), originalPos.y + Random.Range(min_Y, max_Y), transform.position.z);
	}
}
