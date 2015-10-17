using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

	private LineRenderer lineRenderer;

	private float maxZ = 0f;

	private int noSegments = 4;

	private Color color = Color.white;

	private float posRange = 2;

	private float radius = 1f;

	private Vector2 midPoint;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent <LineRenderer> ();
		lineRenderer.SetVertexCount (noSegments);
	
		float tempPosX = 0;
		float tempPosY = 0;		

		tempPosX = Random.Range (posRange, posRange+1);
		tempPosY = Random.Range (posRange, posRange+1);

		for (int i = 1; i < noSegments - 1; i++) 
		{	
			lineRenderer.SetPosition(i, new Vector3(tempPosX, tempPosY, 0));
			tempPosX+=Random.Range (posRange, posRange+1);;
		}

				lineRenderer.SetPosition (0, new Vector3(0, 1, 0));

		Vector3 enemyPos = (Vector3) GameObject.Find ("Enemy").transform.position;
		lineRenderer.SetPosition (noSegments - 1, enemyPos);
				Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
