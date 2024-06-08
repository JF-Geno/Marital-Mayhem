using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Background : MonoBehaviour
{

    public GameObject BackgroundToChange;
    public Player p1;
    public Player p2;
    public List<Player> players;


    // Start is called before the first frame update
    void Start()
    {
        Player Player1 = players.First(p => p.playerName == GameValues.player1Name);
        Player Player2 = players.First(p => p.playerName == GameValues.player2Name);
        BackgroundToChange.GetComponent<SpriteRenderer>().sprite = GameValues.Map;
        Player1.playerNumControl = 1;
        Player2.playerNumControl = 2;

        Player newObject1 = Instantiate(Player1, p1.transform.position, p1.transform.rotation);
        Player newObject2 = Instantiate(Player2, p2.transform.position, p2.transform.rotation);

        //Player newObject = Instantiate(p1, PlayerOneCharacter.transform.position, PlayerOneCharacter.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
