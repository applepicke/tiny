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
	protected PlayerActions actions;
	private float joystickThreshold = 0.6f;

	// Moving
	private float force = 20f;

	public void SetInputDevice(int inputDeviceIndex)
	{
		init_actions();
		actions.Device = InputManager.Devices[inputDeviceIndex];
	}

	void init_actions()
	{
		if(actions == null)
			actions = PlayerActions.CreateWithDefaultBindings();
	}

	// Use this for initialization
	void Start ()
	{
		body = gameObject.GetComponent<Rigidbody2D>();
		animator = transform.GetComponent<Animator>();
		playerState = PlayerStates.idle;

		stateAnimMap = new Dictionary<PlayerStates, string>();
		stateAnimMap.Add(PlayerStates.idle,"idle");
		stateAnimMap.Add(PlayerStates.walk, "walk");
	}

	// Update is called once per frame
	void Update ()
	{
		if (actions.Right.IsPressed || actions.Left.IsPressed)
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

		if (actions.Left.IsPressed && actions.Left.Value > joystickThreshold)
		{
			forceVector = Vector2.left * force;
			FaceLeft();
		} 
		else if (actions.Right.IsPressed && actions.Right.Value > joystickThreshold) {
			forceVector = Vector2.right * force;
			FaceRight();
		}

		body.velocity = new Vector2(forceVector.x, body.velocity.y);
	}

}
