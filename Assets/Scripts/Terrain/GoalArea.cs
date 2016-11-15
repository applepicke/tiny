using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {

    public int teamIndex = 0;
    private TeamManager teams;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        teams = GameObject.Find("TeamManager").GetComponent<TeamManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "Ball")
		{
            teams.GetTeam(teamIndex).AddPoint();
            levelManager.ResetBall();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
	}

}
