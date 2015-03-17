using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	static int catchCount;
	static TextMesh textScore;
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
		textScore = GetComponent<TextMesh>();
	}

	public static void UpdateScore() 
	{
		CatchCount++;
		textScore.text = "Saved cats: " + CatchCount + "          Coins: " + CoinsCount;
	}

	public static void UpdateCoinsScore()
	{
		CoinsCount++;
		textScore.text = "Saved cats: " + CatchCount + "          Coins: " + CoinsCount;
	}

	public static void ResetScores()
	{
		CoinsCount = 0;
		CatchCount = 0;
	}


}
