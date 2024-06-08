using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class David_Brother : Player
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

   
}
