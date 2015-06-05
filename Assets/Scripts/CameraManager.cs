using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public float cameraSpeed = 8.0f;

	void Awake ()
	{
		Application.targetFrameRate = 60;
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		Vector3 newPos = transform.position + new Vector3 (1, 0, 0);
		float newXPos = Mathf.Lerp (transform.position.x, newPos.x, cameraSpeed * Time.deltaTime);
		transform.position = new Vector3(newXPos, 0, -10);
	}
}
