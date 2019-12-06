using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegionShield : MonoBehaviour
{

    public GameObject legionShield;

    bool isShieldActivated;
    bool useDefensiveAbility;

    // Start is called before the first frame update
    void Start()
    {
        isShieldActivated = false;
        useDefensiveAbility = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (useDefensiveAbility)
            {
                
                StartCoroutine(activateDefensiveAbility());
            }
        }
    }

    public IEnumerator activateDefensiveAbility(float countdownValue = 10)
    {
        float currCountdown = countdownValue;
        useDefensiveAbility = false;
        isShieldActivated = true;
        legionShield.SetActive(true);

        while (currCountdown > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdown--;
        }

        legionShield.SetActive(false);
        isShieldActivated = false;
        StartCoroutine(defensiveAbilityCoolDown());
    }

    public IEnumerator defensiveAbilityCoolDown(float countdownValue = 15)
    {
        float currCountdownValue = countdownValue;

        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        useDefensiveAbility = true;
    }

    public bool isShieldActivate()
    {
        return isShieldActivated;
    }
}
