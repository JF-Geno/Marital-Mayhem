using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public void Setup(string playerName)
    {
        gameObject.SetActive(true);
        pointsText.text = playerName + " WINS";
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}