using UnityEngine;
using System.Collections;

public class DeadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Restart", 1);
	}
	
	void Restart()
	{
		Application.LoadLevel (0);
	}
}
