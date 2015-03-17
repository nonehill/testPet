using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {

	[HideInInspector] public bool jump = false;
	
	public float catSpeed = 5;
	public float moveForce = 365;
	public float jumpForce = 700;
	public float jumpForwardForce = 700;
	public Transform groundCheck;
	
	public bool grounded = false;
	Rigidbody2D rb2d;
	Animator animator;

	public List<Transform> jumpPoints;

	// Use this for initialization
	void Awake()
	{
		rb2d	 = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() 
	{
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		foreach (Transform pos in jumpPoints) 
		{
			if (Mathf.Abs(transform.position.x - pos.position.x) < 3 && grounded)
			{
				jump = true;
			}
		}	
	}
	
	void FixedUpdate()
	{	
		rb2d.velocity = new Vector2(1f * catSpeed, rb2d.velocity.y);
		
		if(jump)
		{		
			rb2d.AddForce(new Vector2(jumpForwardForce, jumpForce));
			jump = false;
		}	
	}
}
