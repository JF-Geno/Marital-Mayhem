using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterMenu : MonoBehaviour
{
    private Sprite P1name;
    private Image CharacterAbilityM;
    private Image CharacterAbilityR;
    private Image CharacterAbilityU;
    private GameObject P1CharacterPrefab;

    private Sprite P2name;
    private Image CharacterAbilityM_2;
    private Image CharacterAbilityR_2;
    private Image CharacterAbilityU_2;
    private GameObject P2CharacterPrefab;

    private Sprite Character1;
    private Sprite Character2;
    private Sprite Character3;
    private Sprite Character4;
    private Sprite Character5;
    private Sprite Character6;

    private Sprite Character1_2;
    private Sprite Character2_2;
    private Sprite Character3_2;
    private Sprite Character4_2;
    private Sprite Character5_2;
    private Sprite Character6_2;


    public Bill_Man player1;
    public Sarah_Woman player2;
    public David_Brother player3;
    public Jessica_Babysitter player4;
    public Kathy_CatLady player5;
    public Saul_Lawyer player6;

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
        Character1 = player1.headShot;
        Character2 = player2.headShot;
        Character3 = player3.headShot;
        Character4 = player4.headShot;
        Character5 = player5.headShot;
        Character6 = player6.headShot;

        Character1_2 = player1.headShot;
        Character2_2 = player1.headShot;
        Character3_2 = player3.headShot;
        Character4_2 = player4.headShot;
        Character5_2 = player5.headShot;
        Character6_2 = player6.headShot;
    }




    void Start()
    {
        populate();
    }


    public void P1(Bill_Man p1)
    {
        P1name = p1.PlayerNameImage;
        CharacterAbilityM = p1.CharacterAbilityM;
        CharacterAbilityR = p1.CharacterAbilityR;
        CharacterAbilityU = p1.CharacterAbilityU;
        P1CharacterPrefab = p1.CharacterPrefab;


    }
    public void P2(Sarah_Woman p2)
    {
        P1name = p2.PlayerNameImage;
        CharacterAbilityM = p2.CharacterAbilityM;
        CharacterAbilityR = p2.CharacterAbilityR;
        CharacterAbilityU = p2.CharacterAbilityU;
        P1CharacterPrefab = p2.CharacterPrefab;
    }
    public void P3(David_Brother p3)
    {
        P1name = p3.PlayerNameImage;
        CharacterAbilityM = p3.CharacterAbilityM;
        CharacterAbilityR = p3.CharacterAbilityR;
        CharacterAbilityU = p3.CharacterAbilityU;
        P1CharacterPrefab = p3.CharacterPrefab;
    }
    public void P4(Jessica_Babysitter p4)
    {
        P1name = p4.PlayerNameImage;
        CharacterAbilityM = p4.CharacterAbilityM;
        CharacterAbilityR = p4.CharacterAbilityR;
        CharacterAbilityU = p4.CharacterAbilityU;
        P1CharacterPrefab = p4.CharacterPrefab;
    }

    public void P5(Kathy_CatLady p5)
    {
        P1name = p5.PlayerNameImage;
        CharacterAbilityM = p5.CharacterAbilityM;
        CharacterAbilityR = p5.CharacterAbilityR;
        CharacterAbilityU = p5.CharacterAbilityU;
        P1CharacterPrefab = p5.CharacterPrefab;
    }
    public void P6(Saul_Lawyer p6)
    {
        P1name = p6.PlayerNameImage;
        CharacterAbilityM = p6.CharacterAbilityM;
        CharacterAbilityR = p6.CharacterAbilityR;
        CharacterAbilityU = p6.CharacterAbilityU;
        P1CharacterPrefab = p6.CharacterPrefab;
    }




    public void P1_2(Bill_Man p1)
    {
        P2name = p1.PlayerNameImage;
        CharacterAbilityM_2 = p1.CharacterAbilityM;
        CharacterAbilityR_2 = p1.CharacterAbilityR;
        CharacterAbilityU_2 = p1.CharacterAbilityU;
        P2CharacterPrefab = p1.CharacterPrefab;
    }
    public void P2_2(Sarah_Woman p2)
    {
        P2name = p2.PlayerNameImage;
        CharacterAbilityM_2 = p2.CharacterAbilityM;
        CharacterAbilityR_2 = p2.CharacterAbilityR;
        CharacterAbilityU_2 = p2.CharacterAbilityU;
        P2CharacterPrefab = p2.CharacterPrefab;
    }
    public void P3_2(David_Brother p3)
    {
        P2name = p3.PlayerNameImage;
        CharacterAbilityM_2 = p3.CharacterAbilityM;
        CharacterAbilityR_2 = p3.CharacterAbilityR;
        CharacterAbilityU_2 = p3.CharacterAbilityU;
        P2CharacterPrefab = p3.CharacterPrefab;
    }
    public void P4_2(Jessica_Babysitter p4)
    {
        P2name = p4.PlayerNameImage;
        CharacterAbilityM_2 = p4.CharacterAbilityM;
        CharacterAbilityR_2 = p4.CharacterAbilityR;
        CharacterAbilityU_2 = p4.CharacterAbilityU;
        P2CharacterPrefab = p4.CharacterPrefab;
    }

    public void P5_2(Kathy_CatLady p5)
    {
        P2name = p5.PlayerNameImage;
        CharacterAbilityM_2 = p5.CharacterAbilityM;
        CharacterAbilityR_2 = p5.CharacterAbilityR;
        CharacterAbilityU_2 = p5.CharacterAbilityU;
        P2CharacterPrefab = p5.CharacterPrefab;
    }
    public void P6_2(Saul_Lawyer p6)
    {
        P2name = p6.PlayerNameImage;
        CharacterAbilityM_2 = p6.CharacterAbilityM;
        CharacterAbilityR_2 = p6.CharacterAbilityR;
        CharacterAbilityU_2 = p6.CharacterAbilityU;
        P2CharacterPrefab = p6.CharacterPrefab;
    }








}
