using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public float cameraSpeed = 8.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += new Vector3 (cameraSpeed * Time.deltaTime, 0, 0);
	}
}
