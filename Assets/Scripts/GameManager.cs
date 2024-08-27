using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static int HighScore;//if Score is more than HighScore, set HighScore to Score
    public static int Score;//default is 0
    public static int Life = 3;

    public static void ResetScore()//call to reset the score, it wont reset by itself
    {
        Score = 0;
    }
}