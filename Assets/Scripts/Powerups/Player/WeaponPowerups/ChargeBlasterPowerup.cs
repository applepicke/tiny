using UnityEngine;
using System.Collections;

public class ChargeBlasterPowerup : WeaponPowerup {

	public ChargeBlasterPowerup()
	{
		id = "charge_blaster";
		name = "Charge Blaster";
		weapon = new ChargeBlaster();
	}
}
