using UnityEngine;
using System.Collections;
using InControl;

public class PlayerAssignment {

	public int playerNum { get; set; }
	public InputDevice device { get; set; }
	public GameObject playerObject { get; set; }
	public PlayerActions actions { get; set; }

	public void Bind(GameObject player)
	{
		playerObject = player;
		playerObject.GetComponent<Player>().actions = actions;
	}

	public override string ToString()
	{
		return string.Format("Player {0}", playerNum);
	}

}
