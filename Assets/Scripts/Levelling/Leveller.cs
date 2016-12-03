using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Leveller {

	private int level = 0;
	private int experience = 0;

	private Dictionary<int, Powerup> powerupMap;

	// The object that this leveller will make changes to
	public GameObject gameObject { get; set; }

	public Leveller(Dictionary<int, Powerup> powerups)
	{
		powerupMap = powerups;
	}

	private void levelUp()
	{

	}

	public void addExperience()
	{

	}

}
