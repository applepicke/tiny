using UnityEngine;
using System.Collections;

public abstract class TinyWeapon
{
	// Different Fire modes
	// Semiauto you press the trigger each time you want to fire
	// Auto you hold the trigger down to fire continuously
	// Charge you hold the trigger down then release
	public enum FireMode { semiauto, auto, charge}

	public float chargeTime;
	public float reloadDuration;
	public float fireRate;
	public int magSize;
	public FireMode fireMode;
	public Sprite weaponImage;
	public int roundsInMag;

	// Control stuff
	private bool isPressed;
	private float timeSinceFired;
	public bool reloading;
	public float reloadTime;

	public TinyObject holder;
	public Sprite sprite;

	public void OnTriggerPressed()
	{
		if (!reloading)
		{
			switch (fireMode)
			{
				case FireMode.semiauto:
					if (isPressed == false)
						TryToFire();
					break;
				case FireMode.auto:
					timeSinceFired += Time.deltaTime;
					if (timeSinceFired > fireRate)
					{
						timeSinceFired = 0;
						TryToFire();
					}
					break;
				case FireMode.charge:
					chargeTime += Time.deltaTime;
					break;
			}
			isPressed = true;
		}
	}

	public void UpdateReload()
	{ 
		if (reloading)
			reloadTime += Time.deltaTime;

		if(reloadTime>reloadDuration)
		{
			reloading = false;
			reloadTime = 0;
			roundsInMag = magSize;
		}
	}

	public void OnTriggerReleased()
	{
		if (!reloading)
		{
			if (fireMode == FireMode.charge && isPressed)
			{
				TryToFire();
			}

			timeSinceFired = 0;
			isPressed = false;
		}
	}

	public void ReloadWeapon()
	{
		reloading = true;
		reloadTime = 0;
		chargeTime = 0;
	}

	void TryToFire()
	{
		if (roundsInMag > 0 || fireMode == FireMode.charge)
			Fire();
		else
			ReloadWeapon();
	}

	public abstract void Fire();

}
