using UnityEngine;
using System.Collections;
using InControl;

public class Player : Movable {

	// Object
	protected Rigidbody2D body;
	protected Animator animator;
	protected InputDevice input;

	// Controls
	protected PlayerActions actions;

	// Moving
	private float force = 20f;

	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D>();
		animator = transform.GetComponent<Animator>();
		actions = PlayerActions.CreateWithDefaultBindings();

		// Later for multiplayer this should be passed in
		input = InputManager.ActiveDevice;
	}
	
	// Update is called once per frame
	void Update () {
		if (actions.Right.IsPressed || actions.Left.IsPressed)
			Walk();
		else
			StopWalking();
	}

	protected void StopWalking()
	{
		body.velocity = new Vector2(0, body.velocity.y);
		animator.speed = 0f;
	}

	protected void Walk()
	{
		Vector2 forceVector;

		if (actions.Left.IsPressed)
		{
			forceVector = Vector2.left * force;
			FaceLeft();
		} 
		else {
			forceVector = Vector2.right * force;
			FaceRight();
		}

		body.velocity = new Vector2(forceVector.x, body.velocity.y);

		animator.speed = 1f;	
	}

}
