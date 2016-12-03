using UnityEngine;
using System.Collections;

public class SniperPowerup : WeaponPowerup
{
	public SniperPowerup()
	{
		id = "sniper_rifle";
		name = "Sniper Rifle";
		weapon = new Sniper();
	}
}
