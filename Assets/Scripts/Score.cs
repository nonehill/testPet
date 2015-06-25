using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

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

	// Use this for initialization
	void Start()
	{
	}

	public static void UpdateScore() 
	{
		CatchCount++;
		GameObject.Find("Text").GetComponent<Text>().text = "Monsters: " + CatchCount + "          Coins: " + CoinsCount;
	}

	public static void UpdateCoinsScore (int amount)
	{
		CoinsCount += amount;
		GameObject.Find("Text").GetComponent<Text>().text = "Monsters: " + CatchCount + "          Coins: " + CoinsCount;
	}

	public static void ResetScores()
	{
		CoinsCount = 0;
		CatchCount = 0;
	}


}
