using UnityEngine;
using System.Collections;
using System;

public class Speed : Powerup {

	protected new string name = "Speed";
	public static new string id = "speed";

	public override void OnActivated(GameObject gameObject)
	{
		Player player = gameObject.GetComponent<Player>();
		player.force *= 2f; 
	}

	public override void OnDeactivated(GameObject gameObject)
	{
		Player player = gameObject.GetComponent<Player>();
		player.force /= 2f;
	}

}
