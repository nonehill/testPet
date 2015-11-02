using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public AudioSource menuMusic;
	public GameObject canvas;
	public GameObject monstersCanvas;
	public GameObject workshopCanvas;

	public GameObject collectionView;

	Animator canvasAnim;

	// Use this for initialization
	void Start () 
	{
		Invoke ("MovePlatform", 1f);
		canvasAnim = canvas.GetComponent<Animator> ();
	}

	void MovePlatform ()
	{
		canvas.SetActive (true);
	}

	public void PlayPressed () 
	{
		Application.LoadLevel ("MainScene");
	}

	public void MonstersCollectionPressed ()
	{
		canvasAnim.SetBool ("hideMenu", true);
		monstersCanvas.SetActive (true);
		monstersCanvas.SendMessage ("Show");
	}

	public void WorkShopPressed ()
	{
		canvasAnim.SetBool ("hideMenu", true);
		workshopCanvas.SetActive (true);
	}

	public void BackPressed ()
	{ 
		monstersCanvas.SendMessage ("Hide");
		if (workshopCanvas.activeSelf)
		{
			workshopCanvas.SetActive (false);
		}
		canvasAnim.SetBool ("hideMenu", false);
	}
}
