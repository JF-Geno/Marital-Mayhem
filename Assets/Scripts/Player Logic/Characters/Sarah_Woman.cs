using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarah_Woman : Player
{
     protected override void Start()
    {
        base.Start();
        playerNumControl = 2;  // Set the control number for Sarah_Woman
        Debug.Log("Sarah_Woman initialized");
    }

    protected override void Update()
    {
        base.Update();
        // Add any custom behavior for Sarah_Woman here
    }

    
    


}
