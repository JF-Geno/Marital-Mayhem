using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValues 
{
    public static int player1Wins = 0;
    public static int player2Wins = 0;
    public static string PlayerWin = "P2";
    public static string player1Name = "";
    public static string player2Name = "";
    public static Sprite Map;
    public enum DamageTypes
    {
        Melee,
        Ranged,
        Ultimate,
    };

}