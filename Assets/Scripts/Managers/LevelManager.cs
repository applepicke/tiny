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
		
	}

	public void AddPlayer(int device)
	{
		PlayerAssignment assignment = assignments.AddPlayer(device);
		GameObject player = (GameObject)Instantiate(playerPrefab);
		assignment.playerObject = player;
		player.transform.parent = playersObject.transform;
		player.transform.position = new Vector3(playersObject.transform.position.x, playersObject.transform.position.y, 0);
		assignment.InitializeBindings();
	}

	public void RemovePlayer(int playerNum)
	{
		assignments.RemovePlayer(playerNum);
	}
}
