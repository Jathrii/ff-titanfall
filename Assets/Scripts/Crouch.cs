using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{

    private CharacterController cc;
    public KeyCode crouchKey = KeyCode.C;
    private bool m_Crouch = false;

    private float m_originalHeight;
    [SerializeField] private float m_crouchHeight = 0.5f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        m_originalHeight = cc.height;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (m_Crouch)
            {
                m_Crouch = !m_Crouch;
                checkCrouch();
            }
        }

       if(Input.GetKeyDown(crouchKey))
        {
            m_Crouch = !m_Crouch;

            checkCrouch();
        }
    }

    void checkCrouch()
    {
        if (m_Crouch)
        {
            cc.height = m_crouchHeight;
        }

        else
        {
            cc.height = m_originalHeight;
        }
    }
}
