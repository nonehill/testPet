using UnityEngine;
using System.Collections;
public class ForegroundMoving : MonoBehaviour {

	[SerializeField]
	private float groundSpeed;
	
	[SerializeField]
	private float distanceBehindCamera;
	
	public float maxX;
	public float minX;	

	bool canRespawn = true; 

	bool startMoving = false;

	public float timeForStart;

	void Start ()
	{
		Invoke("StartMove", timeForStart);
	}

	void StartMove ()
	{
		startMoving = true;
	}

	// Update is called once per frame
	void Update () 
	{
		if (startMoving)
			transform.position -= new Vector3 (groundSpeed * Time.deltaTime, 0, 0);
		
		if (transform.position.x < distanceBehindCamera && canRespawn)
		{
			startMoving = false;
			canRespawn = false;
			gameObject.GetComponent<Renderer>().enabled = false;
			Invoke("RespawnForegroundObject", 30.0f);
		}
	}

	void RespawnForegroundObject ()
	{
		startMoving = true;
		canRespawn = true;
		gameObject.GetComponent<Renderer>().enabled = true;
		transform.position = new Vector3 (Random.Range(minX, maxX), transform.position.y, transform.position.z);

	}
}
