using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int bestScore;
    public int score;
    public int currentRank;
    public int starQuantity;

    //-------------------// Analytics Value//-------------------//
    public int dead_in_lava;
    public int dead_in_quickSand;
    public int dead_in_quickSandBroken;
    public int bestRank;
   
    public GameData()
    {
    }
}
