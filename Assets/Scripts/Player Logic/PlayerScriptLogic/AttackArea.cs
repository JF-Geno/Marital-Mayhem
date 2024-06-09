using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;

    //public KnockBack KnockBack;

    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Bill_Man
        if (collider.GetComponent<Bill_Man>() != null)
        {
            //KnockBack(collider);
            collider.GetComponent<Bill_Man>().Damage(damage, GameValues.DamageTypes.Melee);
            collider.gameObject.GetComponent<Bill_Man>().UltimateLogic();

        }
        //Sarah_Woman
        if (collider.GetComponent<Sarah_Woman>() != null)
        {
            //KnockBack(collider);
            collider.GetComponent<Sarah_Woman>().Damage(damage, GameValues.DamageTypes.Melee);
            collider.gameObject.GetComponent<Sarah_Woman>().UltimateLogic();
        }

        //David_Brother
        if (collider.GetComponent<David_Brother>() != null)
        {
            //KnockBack(collider);
            collider.GetComponent<David_Brother>().Damage(damage, GameValues.DamageTypes.Melee);
            collider.gameObject.GetComponent<David_Brother>().UltimateLogic();

        }

        //Jessica_Babysitter
        if (collider.GetComponent<Jessica_Babysitter>() != null)
        {
            //KnockBack(collider);
            collider.GetComponent<Jessica_Babysitter>().Damage(damage, GameValues.DamageTypes.Melee);
            collider.gameObject.GetComponent<Jessica_Babysitter>().UltimateLogic();

        }


        //Kathy_CatLady
        if (collider.GetComponent<Kathy_CatLady>() != null)
        {
            //KnockBack(collider);
            collider.GetComponent<Kathy_CatLady>().Damage(damage, GameValues.DamageTypes.Melee);
            collider.gameObject.GetComponent<Kathy_CatLady>().UltimateLogic();

        }

        //Saul_Lawyer
        if (collider.GetComponent<Saul_Lawyer>() != null)
        {
            //KnockBack(collider);
            collider.GetComponent<Saul_Lawyer>().Damage(damage, GameValues.DamageTypes.Melee);
            collider.gameObject.GetComponent<Saul_Lawyer>().UltimateLogic();

        }

    }
}