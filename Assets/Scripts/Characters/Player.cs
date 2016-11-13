using UnityEngine;
using System.Collections.Generic;
using InControl;

enum PlayerStates { idle, walk, jumping }

public class Player : Movable {

	// Object
	protected Rigidbody2D body;
	protected Animator animator;
	protected InputDevice input;
	private PlayerStates playerState;
	private Dictionary<PlayerStates, string> stateAnimMap;

	// Controls
	public PlayerActions actions { get; set; }
	private float joystickThreshold = 0.8f;

	// Moving
	private float force = 20f;
	private float jumpForce = 20000f;
	private float feetOffset = 1.54f;
	protected bool doJump = false;

	// Use this for initialization
	void Start ()
	{
		body = gameObject.GetComponent<Rigidbody2D>();
		animator = transform.GetComponent<Animator>();
		playerState = PlayerStates.idle;

		stateAnimMap = new Dictionary<PlayerStates, string>();
		stateAnimMap.Add(PlayerStates.idle,"idle");
		stateAnimMap.Add(PlayerStates.walk, "walk");

		ChangeState(PlayerStates.idle);
	}

	protected bool IsGrounded()
	{
		return Physics2D.Linecast(transform.position, new Vector2((float)transform.position.x, transform.position.y-feetOffset), 1 << LayerMask.NameToLayer("ground"));
	}

	void FixedUpdate()
	{
		if (actions.Jump.IsPressed && IsGrounded())
		{
			Vector2 force = (transform.up * jumpForce);
			body.AddForce(force);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (actions.Right.Value > joystickThreshold || actions.Left.Value > joystickThreshold)
			Walk();
		else
			Idle();
	}

	private void ChangeState(PlayerStates newState)
	{
		if (playerState != newState)
		{
			playerState = newState;
			animator.Play(stateAnimMap[newState], -1, 0f);
		}
	}

	protected void Idle()
	{
		ChangeState(PlayerStates.idle);
		body.velocity = new Vector2(0, body.velocity.y);
	}

	protected void Walk()
	{
		ChangeState(PlayerStates.walk);

		Vector2 forceVector = body.velocity;

		if (actions.Left.Value > joystickThreshold)
		{
			forceVector = Vector2.left * force;
			FaceLeft();
		} 
		else if (actions.Right.Value > joystickThreshold) {
			forceVector = Vector2.right * force;
			FaceRight();
		}

		body.velocity = new Vector2(forceVector.x, body.velocity.y);
	}

}
