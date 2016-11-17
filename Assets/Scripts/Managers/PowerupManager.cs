using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerupManager {

	private static PowerupManager _instance;
	private static PowerupManager instance
	{
		get
		{
			if (_instance == null)
				_instance = new PowerupManager();

			return _instance;
		}
	}
	

	private Dictionary<string, Powerup> powerups;

	// Use this for initialization
	private PowerupManager () {
		powerups = new Dictionary<string, Powerup>()
		{
			{ Speed.id, new Speed() }
		};
	}

	public static Powerup FindById(string id)
	{
		return instance.powerups[id];
	}

}
