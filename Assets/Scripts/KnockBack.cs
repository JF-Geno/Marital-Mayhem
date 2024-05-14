using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    private Rigidbody2D m_Rigidbody2D;
    public bool KnockFromRight;
   
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
            m_Rigidbody2D.velocity = new Vector3(-KBForce, KBForce);
        }
        else
        {
            m_Rigidbody2D.velocity = new Vector3(KBForce, KBForce);
        }

        KBCounter -= Time.deltaTime;
    }
     
   
}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
