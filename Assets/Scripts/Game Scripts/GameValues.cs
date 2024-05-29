using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValues
{
    public static int player1Wins = 0;
    public static int player2Wins = 0;
    public static string player1Name = "Player 1";
    public static string player2Name = "Player 2";
    public enum DamageTypes
    {
        Melee,
        Ranged,
        Ultimate,
    };
}