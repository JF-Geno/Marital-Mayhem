using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bill_Man : Player
{
   
   protected override void Start()
    {
        base.Start();
        playerNumControl = 1;  // Set the control number for Bill_Man
        Debug.Log("Bill_Man initialized");
    }

    protected override void Update()
    {
        base.Update();
        // Add any custom behavior for Bill_Man here
    }

     private void OnTriggerEnter2D(Collider2D collider)
    {
        //Bill_Man
          if (collider.GetComponent<Bill_Man>() != null)
        {
            KnockBack(collider);
            collider.GetComponent<Bill_Man>().Damage(damage, GameValues.DamageTypes.Melee);
            Bill_Man.UltimateLogic();
        }
        if (collider.GetComponent<Bill_Man>() != null)
        {
            KnockBack(collider);
            collider.GetComponent<Bill_Man>().Damage(damage, GameValues.DamageTypes.Ranged);
            Bill_Man.UltimateLogic();
        }
        //Sarah_Woman
        if (collider.GetComponent<Sarah_Woman>() != null)
        {
            KnockBack(collider);
            collider.GetComponent<Sarah_Woman>().Damage(damage, GameValues.DamageTypes.Melee);
            Sarah_Woman.UltimateLogic();
        }
        if (collider.GetComponent<Sarah_Woman>() != null)
        {
            KnockBack(collider);
            collider.GetComponent<Sarah_Woman>().Damage(damage, GameValues.DamageTypes.Ranged);
            Sarah_Woman.UltimateLogic();
        }
        //David_Brother
         if (collider.GetComponent<David_Brother>() != null)
        {
            KnockBack(collider);
            collider.GetComponent<David_Brother>().Damage(damage, GameValues.DamageTypes.Melee);
            David_Brother.UltimateLogic();
        }
        if (collider.GetComponent<David_Brother>() != null)
        {
            KnockBack(collider);
            collider.GetComponent<David_Brother>().Damage(damage, GameValues.DamageTypes.Ranged);
            David_Brother.UltimateLogic();
        }
        //Jessica_Babysitter
        if (collider.GetComponent<Jessica_Babysitter>() != null)
        {
            KnockBack(collider);
            collider.GetComponent<Jessica_Babysitter>().Damage(damage, GameValues.DamageTypes.Melee);
            Jessica_Babysitter.UltimateLogic();
        }
        if (collider.GetComponent<Jessica_Babysitter>() != null)
        {
            KnockBack(collider);
            collider.GetComponent<Jessica_Babysitter>().Damage(damage, GameValues.DamageTypes.Ranged);
            Jessica_Babysitter.UltimateLogic();
        }

        //Kathy_CatLady
        if (collider.GetComponent<Kathy_CatLady>() != null)
        {
            KnockBack(collider);
            collider.GetComponent<Kathy_CatLady>().Damage(damage, GameValues.DamageTypes.Melee);
            Kathy_CatLady.UltimateLogic();
        }
        if (collider.GetComponent<Kathy_CatLady>() != null)
        {
            KnockBack(collider);
            collider.GetComponent<Kathy_CatLady>().Damage(damage, GameValues.DamageTypes.Ranged);
            Kathy_CatLady.UltimateLogic();
        }
        //Saul_Lawyer
        if (collider.GetComponent<Saul_Lawyer>() != null)
        {
            KnockBack(collider);
            collider.GetComponent<Saul_Lawyer>().Damage(damage, GameValues.DamageTypes.Melee);
            Saul_Lawyer.UltimateLogic();
        }
        if (collider.GetComponent<Saul_Lawyer>() != null)
        {
            KnockBack(collider);
            collider.GetComponent<Saul_Lawyer>().Damage(damage, GameValues.DamageTypes.Ranged);
            Saul_Lawyer.UltimateLogic();
        }



    }


}
