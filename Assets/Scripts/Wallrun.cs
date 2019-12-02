using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Wallrun : MonoBehaviour
{

    private bool isWallR = false;
    private bool isWallL = false;
    private RaycastHit hitR;
    private RaycastHit hitL;
    private int jumpCount = 0;
    private CharacterController cc;
    private FirstPersonController fpc;
    private Rigidbody rb;
    public float runTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        fpc = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (cc.isGrounded)
            jumpCount = 0;

        if (!cc.isGrounded && jumpCount <= 1)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Physics.Raycast(transform.position, transform.right, out hitR, 1))
                {
                    if (hitR.transform.CompareTag("Wall"))
                    {
                        isWallR = true;
                        isWallL = false;
                        jumpCount += 1;
                        rb.useGravity = false;
                        fpc.setGravityMultiplier(0.5f);
                        StartCoroutine(afterRun());
                    }
                }

                if (Physics.Raycast(transform.position, -transform.right, out hitL, 1))
                {
                    if (hitL.transform.CompareTag("Wall"))
                    {
                        isWallR = false;
                        isWallL = true;
                        jumpCount += 1;
                        rb.useGravity = false;
                        fpc.setGravityMultiplier(0.5f);
                        StartCoroutine(afterRun());
                    }
                }

            }


        }

        
    }

    IEnumerator afterRun()
    {
        yield return new WaitForSeconds(runTime);
        isWallR = false;
        isWallL = false;
        rb.useGravity = true;
        jumpCount = 0;
        fpc.setGravityMultiplier(2);
    }
}
