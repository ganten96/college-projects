/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Nick
 */
public class Team 
{
    public float[] color;
    public String name;
    public int score;
    
    public Team(float[] teamColor, String teamName, int teamScore)
    {
        color = teamColor;
        name = teamName;
        score = teamScore;
    }
}
