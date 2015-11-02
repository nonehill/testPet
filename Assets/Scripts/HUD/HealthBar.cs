using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public RectTransform canavasRect;
	public RectTransform healtBarRect;
	public Transform enemyFollow;
	public Slider healthSlider;

	public Text healthText;

	// Update is called once per frame
	void Update () 
	{
		Vector2 v2 = RectTransformUtility.WorldToScreenPoint (Camera.main, enemyFollow.position);
		healtBarRect.transform.position = new Vector3 (enemyFollow.transform.position.x, enemyFollow.transform.position.y + 1, transform.position.z); //enemyFollow.position;// .anchoredPosition = v2 - canavasRect.sizeDelta / 2;// + new Vector2(40, 65);
	}

	public void UpdateText (float healthAfterDamage, float fullHealth)
	{
		Debug.LogWarning ("healthAfter = " + healthAfterDamage + " fullHealth = " + fullHealth);
		 
		healthSlider.value = healthAfterDamage / fullHealth;
		healthText.text = healthAfterDamage + " / " + fullHealth;
	}
}
