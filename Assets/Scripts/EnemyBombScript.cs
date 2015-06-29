using UnityEngine;
using System.Collections;

public class EnemyBombScript : MonoBehaviour {

	public Transform parent;

	// Use this for initialization
	void OnEnable () {
		gameObject.transform.SetParent (parent);
	}


	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x < -5)
		{
			gameObject.transform.parent = null;

			gameObject.SetActive(false);
			transform.position = new Vector3(9, -1, 0);
		}
	}
}
