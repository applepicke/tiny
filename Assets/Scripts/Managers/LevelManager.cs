using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public GameObject playerPrefab;
    public GameObject ballPrefab;
	private GameObject playersObject;
	private PlayerAssignmentManager assignments;
    private TeamManager teams;
    private float ballRespawnTimer;

	// Use this for initialization
	void Start ()
	{
		assignments = GameObject.Find("PlayerAssignmentManager").GetComponent<PlayerAssignmentManager>();
        teams = GameObject.Find("TeamManager").GetComponent<TeamManager>();
        playersObject = GameObject.Find("Players");

        ballRespawnTimer = 3;
	}
	
	// Update is called once per frame
	void Update ()
	{
		AddUnboundPlayers();
        CheckBallRespawn();
    }

    void CheckBallRespawn()
    {
        // if the ball drops below the killZ, destroy it;
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null && ball.transform.position.y < -25)
            ResetBall();

        // If there is no ball on the map, and the timer isn't running, start the timer
        if (GameObject.FindGameObjectWithTag("Ball") == null && ballRespawnTimer <= 0)
            Instantiate(ballPrefab, new Vector3(0, 50, 10), Quaternion.identity);
        else
            ballRespawnTimer -= Time.deltaTime;
    }

    public void ResetBall()
    {
        Destroy(GameObject.FindGameObjectWithTag("Ball"));
        ballRespawnTimer = 3;
    }

    public float GetBallRespawnTime()
    {
        return ballRespawnTimer;
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
