using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {

	[HideInInspector] public bool jump = false;
	
	public float enemySpeed = 5;
	public float jumpForce = 30;

	public Transform groundCheck;

	public bool grounded = false;
	Rigidbody2D rb2d;
	Animator animator;

	float timeBetweenJump = .5f;

	public List<Transform> jumpPoints;

	// Use this for initialization
	void Awake()
	{
		rb2d	 = GetComponent <Rigidbody2D> ();
		animator = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update() 
	{
		timeBetweenJump += Time.deltaTime;
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("JumpPoint") && grounded)
		{
			jump = true;
			Invoke("SecondJump", .4f);
		}

		if (other.CompareTag("DeathJumpPoint"))		
			SecondJump();
	}

	void SecondJump ()
	{
		if (!grounded)
			jump = true;
	}
	
	void FixedUpdate()
	{	
		if (jump)
		{		
			rb2d.velocity = new Vector2(0, jumpForce);
			jump = false;
		}	
	}
}