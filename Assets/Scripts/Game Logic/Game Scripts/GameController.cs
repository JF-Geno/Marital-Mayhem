using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameController : MonoBehaviour
{
    public GameObject BackgroundToChange;

    public Player p1;
    public Player p2;
    public List<Player> players;

    public HUDControl HUD;
    public UltimateBannerManager ultBannerManager;
    // Start is called before the first frame update
    void Start()
    {
        BackgroundToChange.GetComponent<SpriteRenderer>().sprite = GameValues.Map;

        Player Player1 = players.First(p => p.playerName == GameValues.player1Name);
        Player1.playerNumControl = 1;
        Player1.HUD = HUD;
        Player newObject1 = Instantiate(Player1, p1.transform.position, p1.transform.rotation);

        Player Player2 = players.First(p => p.playerName == GameValues.player2Name);
        Player2.playerNumControl = 2;
        Player2.HUD = HUD;
        Player newObject2 = Instantiate(Player2, p2.transform.position, p2.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
    }
}