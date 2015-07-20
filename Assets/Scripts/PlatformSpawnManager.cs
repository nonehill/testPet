using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawnManager : MonoBehaviour {

	public List<Transform> platformPositions;

	public static PlatformSpawnManager instance;

	// Use this for initialization
	void Awake ()
	{
		instance = this;
	}

	public Vector3 GetNewPosition ()
	{
		Transform lastTransform = platformPositions[platformPositions.Count - 1];
		Vector3 v3 = new Vector3(lastTransform.position.x, lastTransform.position.y, lastTransform.position.z);
		return v3;
	}

	public void SetLastPlatformTransform ()
	{
		Transform lastTransfrom = platformPositions[0];

		for(int i = 0; i < platformPositions.Count; i++)
		{
			if (i == 0)
				lastTransfrom = platformPositions[i];

			if (i == platformPositions.Count - 1)
				platformPositions[i] = lastTransfrom;
			else
				platformPositions[i] = platformPositions[i+1];
		}
	}
}
