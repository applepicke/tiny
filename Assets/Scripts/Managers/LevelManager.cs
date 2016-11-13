using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public GameObject playerPrefab;
	private GameObject playersObject;
	private PlayerAssignmentManager assignments;

	// Use this for initialization
	void Start ()
	{
		assignments = GameObject.Find("PlayerAssignmentManager").GetComponent<PlayerAssignmentManager>();
		playersObject = GameObject.Find("Players");
	}
	
	// Update is called once per frame
	void Update ()
	{
		AddUnboundPlayers();
	}

	// Finds any assignments without players and adds a player to the game with bindings
	public void AddUnboundPlayers()
	{
		if (assignments.HasUnboundAssignments())
		{
			foreach (var assignment in assignments.GetUnboundAssignments())
			{
				GameObject player = (GameObject)Instantiate(playerPrefab);
				assignment.Bind(player);
				player.transform.parent = playersObject.transform;
				player.transform.position = new Vector3(playersObject.transform.position.x, playersObject.transform.position.y, 0);
			}
		}
	}

	public void RemovePlayer(int playerNum)
	{
		assignments.RemovePlayer(playerNum);
	}
}
