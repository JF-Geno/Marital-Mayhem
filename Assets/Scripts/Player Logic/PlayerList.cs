using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{

    public PlayerMan playerMan;
    public PlayerWoman playerWoman;
    public Player3 player3;
    public Player4 player4;
    public Player5 player5;
    public Player6 player6;

    public List<Player> playerList;

    void Start()
    {
        playerList = new List<Player>
        {
            CreatePlayerFromPlayerMan(playerMan),
            CreatePlayerFromPlayerWoman(playerWoman),
            CreatePlayerFromPlayer3(player3),
            CreatePlayerFromPlayer4(player4),
            CreatePlayerFromPlayer5(player5),
            CreatePlayerFromPlayer6(player6)
        };
    }

    private Player CreatePlayerFromPlayerMan(PlayerMan pm)
    {
        return new Player
        {
            PlayerId = pm.playerId,
            Name = pm.playerName,
            PlayerNameImage = pm.playerNameImage,
            CharacterAbilityM = pm.characterAbilityM,
            CharacterAbilityR = pm.characterAbilityR,
            CharacterAbilityU = pm.characterAbilityU,
            nameIScale = pm.nameIScale,
            nameIPositionX = pm.nameIPositionX,
            nameIPositionY = pm.nameIPositionY,
            headShotImage = pm.headShot,
            CharacterPrefab = pm.characterPrefab
        };
    }

    private Player CreatePlayerFromPlayerWoman(PlayerWoman pw)
    {
        return new Player
        {
            PlayerId = pw.playerId,
            Name = pw.playerName,
            PlayerNameImage = pw.playerNameImage,
            CharacterAbilityM = pw.characterAbilityM,
            CharacterAbilityR = pw.characterAbilityR,
            CharacterAbilityU = pw.characterAbilityU,
            nameIScale = pw.nameIScale,
            nameIPositionX = pw.nameIPositionX,
            nameIPositionY = pw.nameIPositionY,
            headShotImage = pw.headShot,
            CharacterPrefab = pw.characterPrefab
        };
    }

    private Player CreatePlayerFromPlayer3(Player3 p3)
    {
        return new Player
        {
            PlayerId = p3.playerId,
            Name = p3.playerName,
            PlayerNameImage = p3.playerNameImage,
            CharacterAbilityM = p3.characterAbilityM,
            CharacterAbilityR = p3.characterAbilityR,
            CharacterAbilityU = p3.characterAbilityU,
            nameIScale = p3.nameIScale,
            nameIPositionX = p3.nameIPositionX,
            nameIPositionY = p3.nameIPositionY,
            headShotImage = p3.headShot,
            CharacterPrefab = p3.characterPrefab
        };
    }

    private Player CreatePlayerFromPlayer4(Player4 p4)
    {
        return new Player
        {
            PlayerId = p4.playerId,
            Name = p4.playerName,
            PlayerNameImage = p4.playerNameImage,
            CharacterAbilityM = p4.characterAbilityM,
            CharacterAbilityR = p4.characterAbilityR,
            CharacterAbilityU = p4.characterAbilityU,
            nameIScale = p4.nameIScale,
            nameIPositionX = p4.nameIPositionX,
            nameIPositionY = p4.nameIPositionY,
            headShotImage = p4.headShot,
            CharacterPrefab = p4.characterPrefab
        };
    }

    private Player CreatePlayerFromPlayer5(Player5 p5)
    {
        return new Player
        {
            PlayerId = p5.playerId,
            Name = p5.playerName,
            PlayerNameImage = p5.playerNameImage,
            CharacterAbilityM = p5.characterAbilityM,
            CharacterAbilityR = p5.characterAbilityR,
            CharacterAbilityU = p5.characterAbilityU,
            nameIScale = p5.nameIScale,
            nameIPositionX = p5.nameIPositionX,
            nameIPositionY = p5.nameIPositionY,
            headShotImage = p5.headShot,
            CharacterPrefab = p5.characterPrefab
        };
    }

    private Player CreatePlayerFromPlayer6(Player6 p6)
    {
        return new Player
        {
            PlayerId = p6.playerId,
            Name = p6.playerName,
            PlayerNameImage = p6.playerNameImage,
            CharacterAbilityM = p6.characterAbilityM,
            CharacterAbilityR = p6.characterAbilityR,
            CharacterAbilityU = p6.characterAbilityU,
            nameIScale = p6.nameIScale,
            nameIPositionX = p6.nameIPositionX,
            nameIPositionY = p6.nameIPositionY,
            headShotImage = p6.headShot,
            CharacterPrefab = p6.characterPrefab
        };
    }




}
