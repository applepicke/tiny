using UnityEngine;
using System.Collections;

public abstract class Powerup {

	protected string name; // The display name of the powerup
	protected string id; // The identifier key of the powerup 

	public abstract void OnActivated(GameObject gameObject);
	public abstract void OnDeactivated(GameObject gameObject);

}
