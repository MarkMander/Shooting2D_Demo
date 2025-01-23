using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameState 
{
    public int totalScore;

    public GameState()
    {
        //Initialize totalScore variable
        this.totalScore = 0;
    }
}
