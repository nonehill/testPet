using UnityEngine;
using System.Collections;

public class SpawnPlatforms : MonoBehaviour
{
	public int maxPlatforms = 20;
	public GameObject platform;
	public float horizontalMin = 7.5f;
	public float horizontalMax = 14f;
	public float verticalMin = -6f;
	public float verticalMax = 6f;

	public Vector2 originalPos;

	// Use this for initialization
	void Start ()
	{
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < maxPlatforms; i++)
		{
			Vector2 randomPosition = originalPos + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
			Instantiate(platform, randomPosition, Quaternion.identity);
			originalPos = randomPosition;
		}
	}
}
