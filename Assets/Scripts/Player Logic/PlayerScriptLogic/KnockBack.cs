using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float KBForce = 6f;
    public float KBTotalTime = 0.2f;
    private float KBCounter;
    private Rigidbody2D m_Rigidbody2D;
    private bool KnockFromRight;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (KBCounter > 0)
        {
            if (KnockFromRight)
            {
                m_Rigidbody2D.velocity = new Vector2(-KBForce, KBForce / 3);
            }
            else
            {
                m_Rigidbody2D.velocity = new Vector2(KBForce, KBForce / 3);
            }
            KBCounter -= Time.deltaTime;
        }
    }

    public void ApplyKnockBack(bool knockFromRight)
    {
        KnockFromRight = knockFromRight;
        KBCounter = KBTotalTime;
    }
}
