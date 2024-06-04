using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
[System.Serializable]
public class GameOverScreen : MonoBehaviour
{
    public GameObject PlayerWin;
    public Sprite[] Winners;

    public Sprite[] Numbers;
    public GameObject P1Num1;
    public GameObject P1Num2;
    public GameObject P2Num1;
    public GameObject P2Num2;
    public GameObject P1Plus;
    public GameObject P2Plus;

    public void Start()
    {

        if(GameValues.PlayerWin == "P1")
        {
            PlayerWin.GetComponent<SpriteRenderer>().sprite = Winners[0];
        } else
        {
            PlayerWin.GetComponent<SpriteRenderer>().sprite = Winners[1];
        }

        string player1Wins = $"{GameValues.player1Wins}";
        string player2Wins = $"{GameValues.player2Wins}";

        if(GameValues.player1Wins <10)
        {
            P1Num1.GetComponent<SpriteRenderer>().sprite = Numbers[0];
            P1Num2.GetComponent<SpriteRenderer>().sprite = Numbers[int.Parse(player1Wins[0].ToString())];
        } else
        {
            if (GameValues.player1Wins > 99)
            {
                P1Plus.SetActive(true);
                P1Num1.GetComponent<SpriteRenderer>().sprite = Numbers[9];
                P1Num2.GetComponent<SpriteRenderer>().sprite = Numbers[9];
            }
            else
            {
                P1Num1.GetComponent<SpriteRenderer>().sprite = Numbers[int.Parse(player1Wins[0].ToString())];
                P1Num2.GetComponent<SpriteRenderer>().sprite = Numbers[int.Parse(player1Wins[1].ToString())];
            }
        }

        if (GameValues.player2Wins < 10)
        {
            P2Num1.GetComponent<SpriteRenderer>().sprite = Numbers[0];
            P2Num2.GetComponent<SpriteRenderer>().sprite = Numbers[int.Parse(player2Wins[0].ToString())];
        }
        else
        {
            if (GameValues.player2Wins > 99)
            {
                P2Plus.SetActive(true);
                P2Num1.GetComponent<SpriteRenderer>().sprite = Numbers[9];
                P2Num2.GetComponent<SpriteRenderer>().sprite = Numbers[9];
            }
            else
            {
                P2Num1.GetComponent<SpriteRenderer>().sprite = Numbers[int.Parse(player2Wins[0].ToString())];
                P2Num2.GetComponent<SpriteRenderer>().sprite = Numbers[int.Parse(player2Wins[1].ToString())];
            }
        }

    }
    public void Setup(string playerName)
    {
        gameObject.SetActive(true);
        if (playerName == GameValues.player1Name)
        {
            GameValues.player1Wins++;
        }
        else
        {
            GameValues.player2Wins++;
        }
    }
    public void MainMenuButton()
    {
        Debug.Log("Working");
        SceneManager.LoadScene(0);
    }
}