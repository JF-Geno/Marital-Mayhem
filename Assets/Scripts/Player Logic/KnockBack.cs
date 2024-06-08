using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

public float KBForce;
public float KBCounter;
private Rigidbody2D m_Rigidbody2D;
public bool KnockFromRight;

public float KBTotalTime;

   
private void Awake()
{
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

}

void FixedUpdate()
{  
    if(KBCounter > 0)
    {
        if (KnockFromRight == true)
        {
            m_Rigidbody2D.velocity = new Vector3(-KBForce, KBForce/3);
        }
        else
        {
            m_Rigidbody2D.velocity = new Vector3(KBForce, KBForce/3);
        }

        KBCounter -= Time.deltaTime;
    }
}

}
