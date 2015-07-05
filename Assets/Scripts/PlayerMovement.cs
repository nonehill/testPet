using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[HideInInspector] public bool jump = false;

	public float moveForce = 365;
	public float jumpForce = 700;
	public Transform groundCheck;

	public bool grounded = false;
	Rigidbody2D rb2d;
	Animator animator;


	// Use this for initialization
	void Awake()
	{
		rb2d     = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update() 
	{


		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
//		UNITY_EDITOR

//#if UNITY_WEBPLAYER
		if (Input.GetButtonDown ("Jump1") && grounded )
		{
			jump = true;
		}
//#endif

//#if !UNITY_EDITOR		
//		if (Input.touchCount > 0 && grounded )
//		{
//			jump = true;
//		}
//#endif

		if (transform.position.x < - 2 || transform.position.y < -5)
		{
			HUD.ResetScores();
			Application.LoadLevelAsync (2);
		}	
	}

	void FixedUpdate ()
	{
		if (jump)
		{
			rb2d.velocity = new Vector2 (0, jumpForce);
			jump = false;
		}	
	}

}
