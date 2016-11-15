using UnityEngine;
using System.Collections.Generic;

public class TeamManager : MonoBehaviour {

    private List<Team> teams;

    // Use this for initialization
    void Start() {
        teams = new List<Team>();
        // add a couple teams...
        teams.Add(new Team());
        teams.Add(new Team());
    }

    // Update is called once per frame
    void Update() {

    }

    public Team GetTeam(int teamIndex)
    {
        return teams[teamIndex];
    }

    // Assign Player to Team
    void AssignPlayerToTeam(Player newPlayer)
    {
        Team needsPlayer = teams[0];

        foreach (var team in teams)
        {
            if (team.PlayerCount() < needsPlayer.PlayerCount())
                needsPlayer = team;
        }

        needsPlayer.AddPlayer(newPlayer);
    }

    public int GetScore(int teamIndex)
    {
        return teams[teamIndex].GetScore();
    }
}


