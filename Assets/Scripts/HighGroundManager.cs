using UnityEngine;
using System.Collections;

public class HighGroundManager : MonoBehaviour {

	Vector3 originalPos;

	// Use this for initialization
	void Start () {
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < Camera.main.transform.position.x - 20)
			transform.position = new Vector3 (transform.position.x + Random.Range(30, 60), originalPos.y + Random.Range(-2, 2), transform.position.z);
	}
}
