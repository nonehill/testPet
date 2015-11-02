using UnityEngine;
using System.Collections;

public class PowerupManager {

	private static PowerupManager __instance;
	public static PowerupManager instance 
	{
		get 
		{
			if (__instance == null)
			{
				__instance = new PowerupManager ();
			}
			return __instance;
		}
	}

	public bool coinMagnetActivated = false;
}
