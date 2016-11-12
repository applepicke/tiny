using UnityEngine;
using System.Collections;
using InControl;

public class PlayerAssignment {

	public int playerNum { get; set; }
	public int inputDevice { get; set; }
	public GameObject playerObject { get; set; }

	private PlayerActions actions;

	public void InitializeBindings()
	{
		actions = PlayerActions.CreateWithDefaultBindings();

		if (inputDevice >= 0)
			actions.Device = InputManager.Devices[inputDevice];
		else
			actions.Device = InputManager.ActiveDevice;

		playerObject.GetComponent<Player>().actions = actions;
	}

	public override string ToString()
	{
		return string.Format("Player {0}", playerNum);
	}

}
