using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[HideInInspector] public bool jump = false;

	public float catSpeed = 5;
	public float moveForce = 365;
	public float jumpForce = 700;
	public float jumpForwardForce = 700;
	public Transform groundCheck;

	bool grounded = false;
	Rigidbody2D rb2d;
	Animator animator;

	// Use this for initialization
	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update() 
	{
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (Input.GetButtonDown ("Jump") && grounded)
		{
			jump = true;
		}

	}

	void FixedUpdate()
	{
		if (transform.position.x < Camera.main.transform.position.x - 10 || transform.position.y < Camera.main.transform.position.y - 10)
		{
			Score.ResetScores();
			Application.LoadLevel (1);
		}

		rb2d.velocity = new Vector2(1f * catSpeed, rb2d.velocity.y);

		
		if(jump)
	  	{		
			Debug.Log("jump");
			rb2d.AddForce(new Vector2(jumpForwardForce, jumpForce));
			jump = false;
		}	
	}
}
