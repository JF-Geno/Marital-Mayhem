using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public TextMeshProUGUI winStatsText;
    public void Setup(string playerName)
    {
        gameObject.SetActive(true);
        winText.text = playerName + " WINS";
        if (playerName == GameValues.player1Name)
        {
            GameValues.player1Wins++;
        }
        else
        {
            GameValues.player2Wins++;
        }
        winStatsText.text = $"{GameValues.player1Name}: {GameValues.player1Wins}\t{GameValues.player2Name}: {GameValues.player2Wins}";
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}