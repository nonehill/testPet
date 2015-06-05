using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < Camera.main.transform.position.x - 25)
			transform.position = new Vector3 (transform.position.x + 52, transform.position.y, transform.position.z);
	}
}
