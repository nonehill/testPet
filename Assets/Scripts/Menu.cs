using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void PlayPressed () 
	{
		Application.LoadLevel ("MainScene");
	}
}
