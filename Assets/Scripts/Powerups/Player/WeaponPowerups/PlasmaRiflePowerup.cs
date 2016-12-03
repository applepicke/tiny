using UnityEngine;
using System.Collections;

public class PlasmaRiflePowerup : WeaponPowerup
{

	public PlasmaRiflePowerup()
	{
		id = "plasma_rifle";
		name = "Plasma Rifle";
		weapon = new PlasmaRifle();
	}
}