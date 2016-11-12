using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using InControl;

public class TooManyPlayersException : Exception { };
public class MultipleBindingException : Exception { };

public class PlayerAssignmentManager : MonoBehaviour {

	private int maxPlayers = 4;
	private int connectedPlayers = 0;
	private List<PlayerAssignment> assignments = new List<PlayerAssignment>();
	private List<InputDevice> devices = new List<InputDevice>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool canAddPlayer()
	{
		return connectedPlayers < maxPlayers;
	}

	// Add a player and return that new player's player num
	public PlayerAssignment AddPlayer(int device)
	{
		if (connectedPlayers == maxPlayers)
			throw new TooManyPlayersException();

		// You can't have more than one player on the same device
		var existing = assignments.FindAll(a => a.inputDevice == device);
		if (existing.Count > 0)
			throw new MultipleBindingException();

		connectedPlayers++;

		var assignment = new PlayerAssignment()
		{
			playerNum = connectedPlayers,
			inputDevice = device,
		};

		assignments.Add(assignment);

		return assignment;
	}

	public void RemovePlayer(int playerNum)
	{
		assignments.RemoveAll(a => a.playerNum == playerNum);
	}

	public override string ToString()
	{
		return string.Format("{0} players connected", connectedPlayers);
	}


}
