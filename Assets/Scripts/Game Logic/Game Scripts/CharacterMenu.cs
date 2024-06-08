using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
[System.Serializable]
public class CharacterMenu : MonoBehaviour
{
    //private Image CharacterAbilityM;
    //private Image CharacterAbilityR;
    //private Image CharacterAbilityU;

    //private Image CharacterAbilityM_2;
    //private Image CharacterAbilityR_2;
    //private Image CharacterAbilityU_2;

    //private Sprite Character1;
    //private Sprite Character2;
    //private Sprite Character3;
    //private Sprite Character4;
    //private Sprite Character5;
    //private Sprite Character6;

    //private Sprite Character1_2;
    //private Sprite Character2_2;
    //private Sprite Character3_2;
    //private Sprite Character4_2;
    //private Sprite Character5_2;
    //private Sprite Character6_2;

    //public Bill_Man player1;
    //public Sarah_Woman player2;
    //public David_Brother player3;
    //public Jessica_Babysitter player4;
    //public Kathy_CatLady player5;
    //public Saul_Lawyer player6;

    //public List<Player> playerList;

    private Player P1Character;
    private Player P2Character;
    public GameObject PlayerOneName;
    public GameObject PlayerTwoName;
    public GameObject PlayerOneCharacter;
    public GameObject PlayerTwoCharacter;

    public void MapMenu()
    {
        GameValues.Player1 = P1Character;
        GameValues.Player2 = P2Character;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void update()
    {

    }

    public void populate()
    {
        //Character1 = player1.headShot;
        //Character2 = player2.headShot;
        //Character3 = player3.headShot;
        //Character4 = player4.headShot;
        //Character5 = player5.headShot;
        //Character6 = player6.headShot;

        //Character1_2 = player1.headShot;
        //Character2_2 = player1.headShot;
        //Character3_2 = player3.headShot;
        //Character4_2 = player4.headShot;
        //Character5_2 = player5.headShot;
        //Character6_2 = player6.headShot;
    }

    void Start()
    {
        //PlayerOneName = transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
        //P1Name = GameObject.Find("Character Names/P1 Name Container/P1 Name");
        populate();
    }

    //public GameObject currentPrefab; // This will be the prefab currently in use
    //public GameObject newPrefab; // This will be the prefab you want to switch to
    public void P1(Player p1)
    {
        PlayerOneName.GetComponent<SpriteRenderer>().sprite = p1.PlayerNameImage;
        P1Character = p1;

        // Instantiate the new prefab
        Player newObject = Instantiate(p1, PlayerOneCharacter.transform.position, PlayerOneCharacter.transform.rotation);

        // Optionally, copy some properties from the old to the new one
        newObject.transform.parent = PlayerOneCharacter.transform.parent;

        // Destroy the old prefab instance
        Destroy(PlayerOneCharacter);

        // Update the currentPrefab reference
        PlayerOneCharacter = transform.GetChild(0).GetChild(9).gameObject; ;

        //CharacterAbilityM = p1.CharacterAbilityM;
        //CharacterAbilityR = p1.CharacterAbilityR;
        //CharacterAbilityU = p1.CharacterAbilityU;
    }

    public void P2(Player p2)
    {
        PlayerTwoName.GetComponent<SpriteRenderer>().sprite = p2.PlayerNameImage;
        P2Character = p2;

        Player newObject = Instantiate(p2, PlayerTwoCharacter.transform.position, PlayerTwoCharacter.transform.rotation);

        // Optionally, copy some properties from the old to the new one
        newObject.transform.parent = PlayerTwoCharacter.transform.parent;

        // Destroy the old prefab instance
        Destroy(PlayerTwoCharacter);

        // Update the currentPrefab reference
        PlayerTwoCharacter = transform.GetChild(1).GetChild(9).gameObject; ;
    }

    //public void P1_2(Bill_Man p1)
    //{
    //    P2name = p1.PlayerNameImage;
    //    CharacterAbilityM_2 = p1.CharacterAbilityM;
    //    CharacterAbilityR_2 = p1.CharacterAbilityR;
    //    CharacterAbilityU_2 = p1.CharacterAbilityU;
    //    P2Character = p1;
    //}
    //public void P2_2(Sarah_Woman p2)
    //{
    //    P2name = p2.PlayerNameImage;
    //    CharacterAbilityM_2 = p2.CharacterAbilityM;
    //    CharacterAbilityR_2 = p2.CharacterAbilityR;
    //    CharacterAbilityU_2 = p2.CharacterAbilityU;
    //    P2Character = p2;
    //}
    //public void P3_2(David_Brother p3)
    //{
    //    P2name = p3.PlayerNameImage;
    //    CharacterAbilityM_2 = p3.CharacterAbilityM;
    //    CharacterAbilityR_2 = p3.CharacterAbilityR;
    //    CharacterAbilityU_2 = p3.CharacterAbilityU;
    //    P2Character = p3;
    //}
    //public void P4_2(Jessica_Babysitter p4)
    //{
    //    P2name = p4.PlayerNameImage;
    //    CharacterAbilityM_2 = p4.CharacterAbilityM;
    //    CharacterAbilityR_2 = p4.CharacterAbilityR;
    //    CharacterAbilityU_2 = p4.CharacterAbilityU;
    //    P2Character = p4;
    //}

    //public void P5_2(Kathy_CatLady p5)
    //{
    //    P2name = p5.PlayerNameImage;
    //    CharacterAbilityM_2 = p5.CharacterAbilityM;
    //    CharacterAbilityR_2 = p5.CharacterAbilityR;
    //    CharacterAbilityU_2 = p5.CharacterAbilityU;
    //    P2Character = p5;
    //}
    //public void P6_2(Saul_Lawyer p6)
    //{
    //    P2name = p6.PlayerNameImage;
    //    CharacterAbilityM_2 = p6.CharacterAbilityM;
    //    CharacterAbilityR_2 = p6.CharacterAbilityR;
    //    CharacterAbilityU_2 = p6.CharacterAbilityU;
    //    P2Character = p6;
    //}








}
