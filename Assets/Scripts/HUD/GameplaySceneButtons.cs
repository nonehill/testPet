using UnityEngine;
using System.Collections;

public class GameplaySceneButtons : MonoBehaviour {

	public GameObject pausePanel;

	public void Pause () 
	{
		Time.timeScale = 0;
		pausePanel.SetActive (true);
	}

	public void Continue ()
	{
		Time.timeScale = 1;
		pausePanel.SetActive (false);
	}

	public void Menu ()
	{
		Time.timeScale = 1;
		Application.LoadLevel (0);
	}
}
