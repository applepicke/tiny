using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    // can abstract this if you think there will
    // ever be more than two teams
    public Text TeamScore0, TeamScore1;
    public Text ballRespawnText;
    private TeamManager teamManager;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        teamManager = GameObject.Find("TeamManager").GetComponent<TeamManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
        TeamScore0.text = "Score: " + teamManager.GetScore(0);
        TeamScore1.text = "Score: " + teamManager.GetScore(1);
        ballRespawnText.enabled = (levelManager.GetBallRespawnTime() > 0);
        ballRespawnText.text = ""+(int)levelManager.GetBallRespawnTime();
    }
}
