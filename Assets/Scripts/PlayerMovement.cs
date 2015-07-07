using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[HideInInspector] public bool jump = false;

	public float moveForce = 365;
	public float jumpForce = 100;
	public Transform groundCheck;

	public bool grounded = false;
	Rigidbody2D rb2d;
	Animator animator;

	bool firstJump = false;
	bool secondJump = false;

	bool firePressed = false;

	PlayerShoot playerShoot;

	// Use this for initialization
	void Awake()
	{
		rb2d     = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	void Start ()
	{
		playerShoot = GameObject.Find("Gun").GetComponent<PlayerShoot>();
	}
	
	// Update is called once per frame
	void Update() 
	{

		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

#if UNITY_EDITOR
		if (Input.GetButtonDown ("Jump1") && grounded)
		{
			jump = true;
			firstJump = true;
		}
		else if (Input.GetButtonDown ("Jump1") && firstJump)
		{
			jump = true;
			secondJump = true;
		}
#endif

#if !UNITY_EDITOR		
		for (int i = 0; i < Input.touchCount; ++i)
		{
			if ((Input.touchCount == 1 && Input.GetTouch(i).phase == TouchPhase.Began && !firePressed) ||
			    (Input.touchCount > 1 && Input.GetTouch(i).phase == TouchPhase.Began && firePressed))
			{
				if (grounded)
				{
					jump = true;
					firstJump = true;
				}
				else if (firstJump)
				{
					jump = true;
					secondJump = true;
				}
			}
		}
#endif

		if (transform.position.x < - 2 || transform.position.y < -5)
		{
			HUD.ResetScores();
			Application.LoadLevelAsync (2);
		}	
	}

	public void JumpPressed ()
	{	
		Debug.Log("Jump");
		if (grounded)
		{
			jump = true;
			firstJump = true;
		}
		else if (firstJump)
		{
			jump = true;
			secondJump = true;
		}
	}

	public void FirePressed ()
	{
		Debug.Log("Fire");
		playerShoot.Fire();
		firePressed = true;
	}

	public void StopFire ()
	{
		Debug.Log("Stop");
		playerShoot.StopFire();

		firePressed = false;
	}

	void FixedUpdate ()
	{
		if (jump)
		{
			rb2d.velocity = new Vector2 (0, jumpForce);
			jump = false;

			if (secondJump)
			{
				firstJump = false;
				secondJump = false;
			}
		}	
	}
}
