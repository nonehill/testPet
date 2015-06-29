using UnityEngine;
using System.Collections;

public class ElementsSpeedManager : MonoBehaviour {

	public static ElementsSpeedManager instance;
	public float levelSpeed;

	// Use this for initialization
	void Awake () 
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
