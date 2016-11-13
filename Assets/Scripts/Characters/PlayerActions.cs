using InControl;
using UnityEngine;


public class PlayerActions : PlayerActionSet
{
	public PlayerAction Left;
	public PlayerAction Right;
	public PlayerOneAxisAction Move;

	public PlayerAction Join;

	public PlayerActions()
	{
		Left = CreatePlayerAction("Move Left");
		Right = CreatePlayerAction("Move Right");
		Move = CreateOneAxisPlayerAction(Left, Right);

		Join = CreatePlayerAction("Join");
	}


	public static PlayerActions CreateWithDefaultBindings()
	{
		var playerActions = new PlayerActions();


		// Movement
		playerActions.Left.AddDefaultBinding(Key.LeftArrow);
		playerActions.Right.AddDefaultBinding(Key.RightArrow);
		playerActions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
		playerActions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
		playerActions.Left.AddDefaultBinding(InputControlType.DPadLeft);
		playerActions.Right.AddDefaultBinding(InputControlType.DPadRight);

		// Joining the game
		playerActions.Join.AddDefaultBinding(InputControlType.Start);
		playerActions.Join.AddDefaultBinding(Key.Return);

		return playerActions;
	}
}
