using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	
	[HideInInspector]
	public bool isFacingRight = true;
	
	[HideInInspector]
	public bool isJumping = false;
	
	[HideInInspector]
	public bool isGrounded = false;
	
	public float jumpForce = 650.0f;
	public float maxSpeed = 7.0f;
	
	public Transform groundCheck;
	public LayerMask groundLayers;
	
	private float groundCheckRadius = 0.2f;

	// added for Chapter 6
	private Animator anim;
	
	void Start()
	{
		anim = this.GetComponent<Animator>();


	}
	
	void Update()
	{
		if(Input.GetButtonDown("Jump"))
		{
			if(isGrounded == true)
			{
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,0);
				this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
				// added for chapter 6
				this.anim.SetTrigger("Jump");
			}
		}
	}
	
	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle
			(groundCheck.position, groundCheckRadius, groundLayers);
		try
		{
			float move = Input.GetAxis("Horizontal");
			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

			//added for chapter 6
			this.anim.SetFloat("Speed",Mathf.Abs(move));

			if((move > 0.0f && isFacingRight == false) || (move < 0.0f && isFacingRight == true))
			{
				Flip ();
			}
		}
		catch(UnityException error)
		{
			Debug.LogError(error.ToString());
		}
	}

	void Flip()
	{
		isFacingRight = !isFacingRight;						
		Vector3 playerScale = transform.localScale;			
		playerScale.x = playerScale.x * -1;					
		transform.localScale = playerScale;				    
	}
}