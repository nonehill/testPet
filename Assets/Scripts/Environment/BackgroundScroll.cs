using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	public float speed = 0;
	float posX = 0;

	// Update is called once per frame
	void Update () {
		posX += speed * Time.timeScale;

		if (posX > 1.0f)
			posX -= 1.0f;

		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(posX, 0);
	}
}
