using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public TextMeshProUGUI winStatsText;
    public GameObject music;
    public GameObject youSuck;
    public float timeLeft = 3.0f;
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

        music.SetActive(false);
        youSuck.SetActive(true);  
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}