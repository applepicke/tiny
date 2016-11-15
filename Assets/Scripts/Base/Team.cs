using UnityEngine;
using System.Collections.Generic;

public class Team
{
    private int score = 0;
    private List<Player> players;

    public void AddPlayer(Player playerToAdd)
    {
        players.Add(playerToAdd);
    }

    public int PlayerCount()
    {
        return players.Count;
    }

    public void AddPoint()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }

}
