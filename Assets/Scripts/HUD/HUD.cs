using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public List<GameObject> hearts;
	public List<GameObject> hearts2;

	static Text scoreLbl;

	static int catchCount;
	static int CatchCount
	{
		get
		{
			return catchCount;
		}
		
		set
		{
			catchCount = value;
		}
	}
	
	static int coinsCount;
	static int CoinsCount
	{
		get
		{
			return coinsCount;
		}
		
		set
		{
			coinsCount = value;
		}
	}

	public static HUD instance;

	void Awake ()
	{
		instance = this;

		scoreLbl = GameObject.Find ("ScoreLbl").GetComponent<Text> ();
	}

	public void FullHealth ()
	{
		for (int i = 0; i < hearts.Count; i++)
		{
			hearts[i].gameObject.SetActive(true);
		}
	}

	public void ReduceHeart ()
	{
		for (int i = 0; i < hearts.Count; i++)
		{
			if (hearts[i].gameObject.activeSelf)
			{
				hearts[i].gameObject.SetActive(false);
				break;
			}
		}
	}
	
	public static void UpdateScore() 
	{
		CatchCount++;
		scoreLbl.text = "Monsters: " + CatchCount + "          Coins: " + CoinsCount;
	}
	
	public static void UpdateCoinsScore (int amount)
	{
		CoinsCount += amount;
		scoreLbl.text = "Monsters: " + CatchCount + "          Coins: " + CoinsCount;
	}
	
	public static void ResetScores()
	{
		CoinsCount = 0;
		CatchCount = 0;
	}

}
