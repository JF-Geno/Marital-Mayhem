using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject manPrefab;
    public GameObject womanPrefab;

    private GameObject player1;
    private GameObject player2;

    void Start()
    {
        // For testing, instantiate characters directly
        InstantiateCharacter(manPrefab, 1);
        InstantiateCharacter(womanPrefab, 2);
    }

    public void InstantiateCharacter(GameObject characterPrefab, int playerNumber)
    {
        GameObject characterInstance = Instantiate(characterPrefab);

        if (playerNumber == 1)
        {
            player1 = characterInstance;
            characterInstance.AddComponent<P1Controls>();
        }
        else if (playerNumber == 2)
        {
            player2 = characterInstance;
            characterInstance.AddComponent<P2Controls>();
        }
    }
}
