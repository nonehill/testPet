using UnityEngine;
using System.Collections;

public enum AmmoType {
	Gun = 0,
	Rocket = 1
}

public class AmmoManager : MonoBehaviour {

	public static AmmoType ammotype;

	void Awake ()
	{
		ammotype = AmmoType.Gun;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
