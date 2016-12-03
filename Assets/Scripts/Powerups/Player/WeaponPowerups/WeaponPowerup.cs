using UnityEngine;
using System.Collections;

public class WeaponPowerup : Powerup {

	protected TinyWeapon weapon;

	public override void OnActivated(TinyObject tiny)
	{
		var player = (Player) tiny;
		player.weapon1 = weapon;
		weapon.holder = player;
	}

	public override void OnDeactivated(TinyObject tiny)
	{
		
	}

}

