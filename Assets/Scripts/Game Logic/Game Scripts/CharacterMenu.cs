using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    private Image P1name;
    private Image CharacterAbilityM;
    private Image CharacterAbilityR;
    private Image CharacterAbilityU;
    private GameObject P1CharacterPrefab;

    private Image P2name;
    private Image CharacterAbilityM_2;
    private Image CharacterAbilityR_2;
    private Image CharacterAbilityU_2;
    private GameObject P2CharacterPrefab;

    private Image Character1;
    private Image Character2;
    private Image Character3;
    private Image Character4;
    private Image Character5;
    private Image Character6;

    private Image Character1_2;
    private Image Character2_2;
    private Image Character3_2;
    private Image Character4_2;
    private Image Character5_2;
    private Image Character6_2;


    public PlayerMan playerMan;
    public PlayerWoman playerWoman;
    public Player3 player3;
    public Player4 player4;
    public Player5 player5;
    public Player6 player6;

    public List<Player> playerList;



    public void MapMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void update()
    {

    }

    public void populate()
    {
        Character1 = playerMan.headShot;
        Character2 = playerWoman.headShot;
        Character3 = player3.headShot;
        Character4 = player4.headShot;
        Character5 = player5.headShot;
        Character6 = player6.headShot;

        Character1_2 = playerMan.headShot;
        Character2_2 = playerWoman.headShot;
        Character3_2 = player3.headShot;
        Character4_2 = player4.headShot;
        Character5_2 = player5.headShot;
        Character6_2 = player6.headShot;
    }




    void Start()
    {
        populate();
    }


    public void P1(PlayerMan pm)
    {
        P1name = pm.PlayerNameImage;
        CharacterAbilityM = pm.characterAbilityM;
        CharacterAbilityR = pm.characterAbilityR;
        CharacterAbilityU = pm.characterAbilityU;
        P1CharacterPrefab = pm.characterPrefab;


    }
    public void P2(PlayerWoman pw)
    {
        P1name = pw.PlayerNameImage;
        CharacterAbilityM = pw.characterAbilityM;
        CharacterAbilityR = pw.characterAbilityR;
        CharacterAbilityU = pw.characterAbilityU;
        P1CharacterPrefab = pw.characterPrefab;
    }
    public void P3(Player3 p3)
    {
        P1name = p3.PlayerNameImage;
        CharacterAbilityM = p3.characterAbilityM;
        CharacterAbilityR = p3.characterAbilityR;
        CharacterAbilityU = p3.characterAbilityU;
        P1CharacterPrefab = p3.characterPrefab;
    }
    public void P4(Player4 p4)
    {
        P1name = p4.PlayerNameImage;
        CharacterAbilityM = p4.characterAbilityM;
        CharacterAbilityR = p4.characterAbilityR;
        CharacterAbilityU = p4.characterAbilityU;
        P1CharacterPrefab = p4.characterPrefab;
    }

    public void P5(Player5 p5)
    {
        P1name = p5.PlayerNameImage;
        CharacterAbilityM = p5.characterAbilityM;
        CharacterAbilityR = p5.characterAbilityR;
        CharacterAbilityU = p5.characterAbilityU;
        P1CharacterPrefab = p5.characterPrefab;
    }
    public void P6(Player3 p6)
    {
        P1name = p6.PlayerNameImage;
        CharacterAbilityM = p6.characterAbilityM;
        CharacterAbilityR = p6.characterAbilityR;
        CharacterAbilityU = p6.characterAbilityU;
        P1CharacterPrefab = p6.characterPrefab;
    }




    public void P1_2(PlayerMan pm)
    {
        P2name = pm.PlayerNameImage;
        CharacterAbilityM_2 = pm.characterAbilityM;
        CharacterAbilityR_2 = pm.characterAbilityR;
        CharacterAbilityU_2 = pm.characterAbilityU;
        P2CharacterPrefab = pm.characterPrefab;
    }
    public void P2_2(PlayerWoman pw)
    {
        P2name = pw.PlayerNameImage;
        CharacterAbilityM_2 = pw.characterAbilityM;
        CharacterAbilityR_2 = pw.characterAbilityR;
        CharacterAbilityU_2 = pw.characterAbilityU;
        P2CharacterPrefab = pw.characterPrefab;
    }
    public void P3_2(Player3 p3)
    {
        P2name = p3.PlayerNameImage;
        CharacterAbilityM_2 = p3.characterAbilityM;
        CharacterAbilityR_2 = p3.characterAbilityR;
        CharacterAbilityU_2 = p3.characterAbilityU;
        P2CharacterPrefab = p3.characterPrefab;
    }
    public void P4_2(Player4 p4)
    {
        P2name = p4.PlayerNameImage;
        CharacterAbilityM_2 = p4.characterAbilityM;
        CharacterAbilityR_2 = p4.characterAbilityR;
        CharacterAbilityU_2 = p4.characterAbilityU;
        P2CharacterPrefab = p4.characterPrefab;
    }

    public void P5_2(Player5 p5)
    {
        P2name = p5.PlayerNameImage;
        CharacterAbilityM_2 = p5.characterAbilityM;
        CharacterAbilityR_2 = p5.characterAbilityR;
        CharacterAbilityU_2 = p5.characterAbilityU;
        P2CharacterPrefab = p5.characterPrefab;
    }
    public void P6_2(Player6 p6)
    {
        P2name = p6.PlayerNameImage;
        CharacterAbilityM_2 = p6.characterAbilityM;
        CharacterAbilityR_2 = p6.characterAbilityR;
        CharacterAbilityU_2 = p6.characterAbilityU;
        P2CharacterPrefab = p6.characterPrefab;
    }








}
