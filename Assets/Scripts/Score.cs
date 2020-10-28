using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    private static int score;
    public static int GetScore()
    {
        return score;
    }

    public static void AddScore(int value)
    {
        score += value;
    }

    public static void InitializeStatic()
    {
        score = 0;
    }

}
