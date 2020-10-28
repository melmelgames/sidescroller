using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Health
{
    private static int health;

    public static int GetHealth()
    {
        return health;
    }

    public static void AddHealth()
    {
        health++;
    }

    public static void SubtractHealth()
    {
        health--;
    }

    public static void InitializeStatic()
    {
        health = 3;
    }
}
