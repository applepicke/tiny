using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public GameObject player_controller;
	public List<GameObject> players;

	// Use this for initialization
	void Start ()
	{
		GameObject playersList = GameObject.Find("Players");
		players.Add((GameObject)Instantiate(player_controller));
		players.Add((GameObject)Instantiate(player_controller));

		int i = 0;
		foreach (var p in players)
		{
			// I guess this is standard practice for parenting new gameobjects
			// to existing gameobjects in the scene
			p.transform.parent = playersList.transform;

			// This assigns each player a different input device
			((Player)p.GetComponent("Player")).SetInputDevice(i);
			i++;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
