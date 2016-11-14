using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InvalidStateException : Exception { }

public class AnimatorStates {

	private string currentState;
	private Animator animator;

	private List<string> states = new List<string>();

	public AnimatorStates(Animator animator, string[] states)
	{
		this.animator = animator;

		foreach (var s in states)
		{
			this.states.Add(s);
		}
	}

	public void AddState(string state)
	{
		states.Add(state);
	}

	public void ChangeState(string state)
	{
		if (!states.Contains(state))
			throw new InvalidStateException();

		if (currentState != state)
		{
			currentState = state;
			animator.Play(state, -1, 0f);
		}
		
	}


}
