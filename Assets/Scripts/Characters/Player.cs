using UnityEngine;
using System.Collections.Generic;
using InControl;

public class Player : Movable {

	// Object
	protected Rigidbody2D body;
	protected Animator animator;
	protected InputDevice input;
	private AnimatorStates states;

	// Controls
	public PlayerActions actions { get; set; }
	private float joystickThreshold = 0.8f;

	// Moving
	private float force = 20f;
	private float jumpForce = 20000f;
	private float feetOffset = 1.54f;

	// Use this for initialization
	void Start ()
	{
		body = gameObject.GetComponent<Rigidbody2D>();
		animator = transform.GetComponent<Animator>();

		states = new AnimatorStates(animator, new string[] {
			"walk",
			"idle",
			"jump"
		});

		states.ChangeState("idle");
	}

	protected bool IsGrounded()
	{
		return Physics2D.Linecast(transform.position, new Vector2((float)transform.position.x, transform.position.y - feetOffset), 1 << LayerMask.NameToLayer("ground"));
	}

	protected bool OnLadder()
	{
		return (body.gravityScale == 0);
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
		if (StickAction())
			Walk();
		else
			Idle();
	}

	protected void Idle()
	{
		states.ChangeState("idle");
		body.velocity = new Vector2(0, (OnLadder() ? 0 : body.velocity.y));
	}

	protected bool StickAction()
	{
		return (actions.Right.Value > joystickThreshold || actions.Left.Value > joystickThreshold || actions.Up.Value > joystickThreshold || actions.Down.Value > joystickThreshold);
	}

	protected void Walk()
	{
		states.ChangeState("walk");

		Vector2 forceVector = body.velocity;

		if (actions.Left.Value > joystickThreshold)
		{
			forceVector = Vector2.left * force;
			FaceLeft();
		}
		else if (actions.Right.Value > joystickThreshold)
		{
			forceVector = Vector2.right * force;
			FaceRight();
		}

		if (OnLadder())
		{
			if (actions.Up.Value > joystickThreshold)
				forceVector.y = force;
			else if (actions.Down.Value > joystickThreshold)
				forceVector.y = -1 * force;
		}
		else
			forceVector.y = body.velocity.y;

		body.velocity = forceVector;
	}
}
