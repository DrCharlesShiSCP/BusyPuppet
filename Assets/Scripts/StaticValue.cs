using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticValue 
{
    public static int currentTurn;
    public static int completedTurn;
    public static Dictionary<string, int> userCommandCounts = new Dictionary<string, int>();
}
