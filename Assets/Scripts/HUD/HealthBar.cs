using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public RectTransform canavasRect;
	public RectTransform healtBarRect;
	public Transform enemyFollow;

	// Update is called once per frame
	void Update () {
		Vector2 v2 = RectTransformUtility.WorldToScreenPoint (Camera.main, enemyFollow.position);
		healtBarRect.anchoredPosition = v2 - canavasRect.sizeDelta / 2 + new Vector2(0, 50);
	}
}
