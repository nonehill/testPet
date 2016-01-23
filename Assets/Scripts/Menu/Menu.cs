using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public AudioSource menuMusic;
	public GameObject cardsWindow;
	public GameObject dailyChallengeWindow;

	// Use this for initialization
	void Start () 
	{
	}

	public void PlayPressed () 
	{
		Application.LoadLevel ("MainScene");
	}

	public void CardsPressed ()
	{
		cardsWindow.SetActive (true);
	}

	public void DailyChallengePressed ()
	{
		dailyChallengeWindow.SetActive (true);
	}

	public void BackPressed ()
	{ 
		if (dailyChallengeWindow.activeSelf)
		{
			dailyChallengeWindow.SetActive (false);
		}
	}

	public void FacebookPressed ()
	{
		Debug.Log ("Facebook PRESSED");
	}

	public void SettingsPressed ()
	{
		Debug.Log ("SettingsPressed PRESSED");
	}

}
