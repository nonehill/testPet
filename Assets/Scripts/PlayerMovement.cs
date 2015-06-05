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
#if UNITY_EDITOR
		if (Input.GetButtonDown ("Jump") && grounded )
		{
			jump = true;
		}
#endif

#if !UNITY_EDITOR		
		if (Input.touchCount > 0 && grounded )
		{
			jump = true;
		}
#endif

		if (transform.position.x < Camera.main.transform.position.x - 10 || transform.position.y < Camera.main.transform.position.y - 10)
		{
			Score.ResetScores();
			Application.LoadLevelAsync (1);
		}	
	}

	void FixedUpdate ()
	{
//		transform.position += new Vector3 (speed * Time.smoothDeltaTime, 0, 0);
		rb2d.velocity = new Vector2 (moveForce, rb2d.velocity.y);

		if (jump)
		{
			rb2d.velocity = new Vector2 (moveForce, jumpForce);
			jump = false;
		}	
	}

}
