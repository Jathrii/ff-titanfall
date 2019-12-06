using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DashMove : MonoBehaviour
{

    private Rigidbody rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private PlayerTitanFirstPersonController fpc;
    private int dashPoints;
    bool isDashing;
    public Text dashPointsText;

    // Start is called before the first frame update
    void Start()
    {
        dashPointsText.gameObject.SetActive(true);
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
        fpc = GetComponent<PlayerTitanFirstPersonController>();
        dashPoints = 3;
        isDashing = false;
    }

    // Update is called once per frame
    void Update()
    {

        dashMove(); 
    }

    void dashMove()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Input.GetKey(KeyCode.A))        
                    direction = 1;

                else if (Input.GetKey(KeyCode.D))
                    direction = 2;

                else if (Input.GetKey(KeyCode.W))
                    direction = 3;

                else if (Input.GetKey(KeyCode.S))
                    direction = 4;
            }
        }

        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                isDashing = false;
                dashTime = startDashTime;
                rb.velocity = Vector3.zero;
                fpc.set_m_WalkSpeed(5);
            }

            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1 && dashPoints > 0 && !isDashing)
                {
                    rb.velocity = Vector3.left * dashSpeed;
                    fpc.set_m_WalkSpeed(dashSpeed);
                    dashPoints--;
                    isDashing = true;
                    StartCoroutine(incrementDashPoints());
                }

                if (direction == 2 && dashPoints > 0 && !isDashing)
                {
                    rb.velocity = Vector3.right * dashSpeed;
                    fpc.set_m_WalkSpeed(dashSpeed);
                    dashPoints--;
                    isDashing = true;
                    StartCoroutine(incrementDashPoints());
                }

                if (direction == 3 && dashPoints > 0 && !isDashing)
                {
                    rb.velocity = Vector3.forward * dashSpeed;
                    fpc.set_m_WalkSpeed(dashSpeed);
                    dashPoints--;
                    isDashing = true;
                    StartCoroutine(incrementDashPoints());
                }

                if (direction == 4 && dashPoints > 0 && !isDashing)
                {
                    rb.velocity = Vector3.back * dashSpeed;
                    fpc.set_m_WalkSpeed(dashSpeed);
                    dashPoints--;
                    isDashing = true;
                    StartCoroutine(incrementDashPoints());
                }

                dashPointsText.text = "Dash Available: " + dashPoints;
            }
        }

    }

    public IEnumerator incrementDashPoints(float countdownValue = 5)
    {
        float currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        if (dashPoints < 3 && !isDashing)
        {
            dashPoints++;
            dashPointsText.text = "Dash Available: " + dashPoints;
        }

    }
}
