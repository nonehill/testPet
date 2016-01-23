using UnityEngine;
using System.Collections;
using System;

public enum WindowKind
{
    Challenge = 0,
    Cards = 1,
    Setings = 2
}

public class Menu : MonoBehaviour {

	public AudioSource menuMusic;
	public GameObject cardsWindow;
	public GameObject dailyChallengeWindow;
    public GameObject settingWindow;

	// Use this for initialization
	void Start () 
	{
        System.Object ob = null;//new Object();
        try
        {
            ob.ToString();
        }
        catch (Exception ex)
        {
            Debug.LogWarning("error " + ex);
        }
        finally
        {
                        Debug.LogWarning("success");
        }
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

	public void BackPressed (int windowKind)
	{ 
        switch ((WindowKind)windowKind)
        {
            case WindowKind.Challenge:
                dailyChallengeWindow.SetActive(false);
                break;
                
            case WindowKind.Cards:
                cardsWindow.SetActive(false);
                break;
                
            case WindowKind.Setings:
                settingWindow.SetActive(false);
                break;
        }
        Debug.LogWarning("BackPressed + " + transform.parent);
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
