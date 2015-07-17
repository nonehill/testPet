using UnityEngine;
using System.Collections;

public class TreesRespawn : MonoBehaviour 
{
	[SerializeField]
	private float groundSpeed;
	
	[SerializeField]
	private float distanceBehindCamera;

	public float maxX;
	public float minX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position -= new Vector3 (groundSpeed * Time.deltaTime, 0, 0);

		if (transform.position.x < distanceBehindCamera)
			transform.position = new Vector3 (Random.Range(minX, maxX), transform.position.y, transform.position.z);
	}
}
