using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class GameOverScreen : MonoBehaviour
{
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