using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

	public static CanvasManager instance;
	public GameObject deathPanel;

	// Use this for initialization
	void Awake ()
	{
		instance = this;
	}
	
	public void ShowDeathPanel ()
	{
		deathPanel.SetActive(true);
	}

	public void HideDeathPanel ()
	{
		deathPanel.SetActive(false);
	}

	public void RestartLevel ()
	{
		Application.LoadLevelAsync(Application.loadedLevelName);
	}

	public void Menu ()
	{
		Application.LoadLevelAsync(0);
	}
}
